using Application.DTO.Response;
using Domain.Entity.V1;
using Domain.Interface;
using Infraestructure.Interface.Patterns;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Core {
    public class MessageDomain : IMessageDomain 
    {
        private readonly MemoryCache _cache;
        private readonly IUnitOfWork _unitOfWork;
        public MessageDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<Message> GetByCode(string code) {
            Message entity = new Message();
            if (!_cache.TryGetValue("Messages", out IEnumerable<Message> messages)) {
                messages = await _unitOfWork.Message.GetAllAsync(); ;
                var seconds = await GetAbsoluteExpiration(messages);
                var cacheExpiryOptions = new MemoryCacheEntryOptions {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(seconds),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromMinutes(2)
                };

                _cache.Set("Messages", messages, cacheExpiryOptions);
                entity = messages.Where(x => x.MessageCode.Equals(code)).FirstOrDefault();

                return entity;
            }
            entity = messages.Where(x => x.MessageCode.Equals(code)).FirstOrDefault();

            return entity;
        }

        private async Task<int> GetAbsoluteExpiration(IEnumerable<Message> messages) {
            int seconds = 900;
            var message = messages
                .Where(x => x.MessageCode.Equals("000")).FirstOrDefault();

            if (message == null) return seconds; //si no existe config retorne 15min  
            if (message.MessageEsp == null) return seconds;
            seconds = Convert.ToInt32(message.MessageEsp);
            return await Task.Run(() => seconds);
        }
    }
}
