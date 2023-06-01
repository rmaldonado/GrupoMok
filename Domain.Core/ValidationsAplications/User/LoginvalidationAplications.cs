using Application.DTO;
using Application.DTO.Request;
using Common;
using Domain.Entity;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Interface.ValidationInterface.User
{
    public class LoginvalidationAplications : ILoginvalidationAplications
    {
        const string RegExpAlphanumeric = @"^[a-zA-Z0-9]+$";
        const string RegExpPassword = @"^(?=.*\d)(?=.*[az])(?=.*[AZ])(?!.*\s).{8,15}$";
        const string RegExpText = @"^[a-zA-Z]+$";
        const string RegExpNumeric = @"^[0-9]+$";
        const string RegExpDecimal = @"^\d+(\.\d{1,2})?$";
        //-Debe tener al menos 8 caracteres
        const string RegExpMayorCaracteres = @"^.*(?=.{8,})(?=.*\\d)";
        //-Debe contener al menos una letra minúscula,
        const string RegExpMinuscula = @"(?=.*[a-z])";
        //-Una letra mayúscula,
        const string RegExpMayuscula = @"(?=.*[A-Z])";
        //-Un dígito y un carácter especial
        const string RegExpPasswordDigitoCaracter = @"(?=.*[@#$%^&+=]).*$";




        public async Task<Validation> ValidationLoguin(LoginRequestDto request)
        {
            DataItem messageValidation = new DataItem();

            Validation validation = new Validation
            {
                Validate = true,
                Message = Constants.OK
            };


            messageValidation = await ValidationLoguinUsersName(request.Username);
            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }

            messageValidation = await ValidationLoguinPassword(request.Password);

            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }


            return await Task.Run(() => validation);
        }

        //****Mensajes 

        private async Task<DataItem> ValidationLoguinUsersName(string Username)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(Username)) return await MessageValidateCampo01("N01");
            if (string.IsNullOrWhiteSpace(Username)) return await MessageValidateCampo01("N02");
            if (Username.Trim().Length < 5) return await MessageValidateCampo01("N03");
            if (Username.Trim().Length > 15) return await MessageValidateCampo01("N04");
            if (!Regex.IsMatch(Username.Trim(), Username)) return await MessageValidateCampo01("N05");

            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> ValidationLoguinPassword(string Password)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(Password)) return await MessageValidateCampo02("N01");
            if (string.IsNullOrWhiteSpace(Password)) return await MessageValidateCampo02("N02");
            if (Password.Trim().Length < 5) return await MessageValidateCampo02("N03");
            if (Password.Trim().Length > 15) return await MessageValidateCampo02("N04");
            if (!Regex.IsMatch(Password.Trim(), RegExpText)) return await MessageValidateCampo02("N05");

            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }


        //***Mensajes Objeto 01 Create***

        // name
        private async Task<DataItem> MessageValidateCampo01(string code)
        {
            DataItem lista = new DataItem();

            switch (code)
            {
                case "N01":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo Nombre no puede estar vacio"
                    };
                    break;
                case "N02":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo Nombre no puede tener espacios en blanco"
                    };
                    break;
                case "N03":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo Nombre debe tener al menos 6 caracteres"
                    };
                    break;
                case "N04":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo Nombre no puede mayor que 15 digitos"
                    };
                    break;
                case "N05":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo Nombre no cumple con los requisitos (,)"
                    };
                    break;
                default:
                    break;
            }
            return await Task.Run(() => lista);
        }

        // Icon
        private async Task<DataItem> MessageValidateCampo02(string code)
        {
            DataItem lista = new DataItem();

            switch (code)
            {
                case "I01":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo Icon no puede estar vacio"
                    };
                    break;
                case "I02":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo Icon no puede tener espacios en blanco"
                    };
                    break;
                case "I03":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo Icon debe tener al menos 6 caracteres"
                    };
                    break;
                case "I04":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo Icon no puede mayor que 15 digitos"
                    };
                    break;
                case "I05":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo Icon no cumple con los requisitos (,)"
                    };
                    break;
                default:
                    break;
            }
            return await Task.Run(() => lista);
        }

    }
}
