using Application.DTO;
using Application.DTO.Request;
using Common;
using Domain.Entity;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Interface.ValidationInterface.User
{
    public class MenuValidationAplications : IMenuValidationAplications
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


        //****Objeto 01
        public async Task<Validation> ValidateMenu(MenuRequestCreateDto request)
        {
            DataItem messageValidation = new DataItem();

            Validation validation = new Validation
            {
                Validate = true,
                Message = Constants.OK
            };


            messageValidation = await ValidationName1(request.Name);
            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }

            messageValidation = await ValidationIcon1(request.Icon);

            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }        

            messageValidation = await ValidationUrl1(request.Name);

            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }

            messageValidation = await ValidationFatherId1(request.ParentId.ToString());

            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }

            messageValidation = await ValidationState1(request.State.ToString());

            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }

            messageValidation = await ValidationAuditCreateUser1(request.AuditCreateUser.ToString());

            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }

            messageValidation = await ValidationAuditCreateDate1(request.AuditCreateDate.ToString());

            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }


            return await Task.Run(() => validation);
        }

       
        //************************************************************************************************


        //*** Logica objeto 01 Create ***

        private async Task<DataItem> ValidationName1(string Name)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(Name)) return await MessageValidateCampo01("N01");
            if (string.IsNullOrWhiteSpace(Name)) return await MessageValidateCampo01("N02");
            if (Name.Trim().Length < 5) return await MessageValidateCampo01("N03");
            if (Name.Trim().Length > 15) return await MessageValidateCampo01("N04");
            if (!Regex.IsMatch(Name.Trim(), RegExpText)) return await MessageValidateCampo01("N05");

            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> ValidationIcon1(string Icon)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(Icon)) return await MessageValidateCampo02("I01");
            if (string.IsNullOrWhiteSpace(Icon)) return await MessageValidateCampo02("I02");
            if (Icon.Trim().Length < 5) return await MessageValidateCampo02("I03");
            if (Icon.Trim().Length > 15) return await MessageValidateCampo02("I04");
            if (!Regex.IsMatch(Icon.Trim(), RegExpText)) return await MessageValidateCampo02("I05");

            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> ValidationUrl1(string Url)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(Url)) return await MessageValidateCampo03("U01");
            if (string.IsNullOrWhiteSpace(Url)) return await MessageValidateCampo03("U02");
            if (Url.Trim().Length < 5) return await MessageValidateCampo03("U03");
            if (Url.Trim().Length > 15) return await MessageValidateCampo03("U04");
            if (!Regex.IsMatch(Url.Trim(), RegExpText)) return await MessageValidateCampo03("U05");

            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> ValidationFatherId1(string FatherId)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(FatherId)) return await MessageValidateCampo04("F01");
            if (string.IsNullOrWhiteSpace(FatherId)) return await MessageValidateCampo04("F02");
            if (FatherId.Trim().Length < 5) return await MessageValidateCampo04("F03");
            if (FatherId.Trim().Length > 15) return await MessageValidateCampo04("F04");
            if (!Regex.IsMatch(FatherId.Trim(), RegExpText)) return await MessageValidateCampo04("F05");

            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> ValidationState1(string State)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(State)) return await MessageValidateCampo05("S01");
            if (string.IsNullOrWhiteSpace(State)) return await MessageValidateCampo05("S02");
            if (State.Trim().Length < 5) return await MessageValidateCampo05("S03");
            if (State.Trim().Length > 15) return await MessageValidateCampo05("S04");
            if (!Regex.IsMatch(State.Trim(), RegExpText)) return await MessageValidateCampo05("S05");

            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> ValidationAuditCreateUser1(string AuditCreateUser)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(AuditCreateUser)) return await MessageValidateCampo06("AU01");
            if (string.IsNullOrWhiteSpace(AuditCreateUser)) return await MessageValidateCampo06("AU02");
            if (AuditCreateUser.Trim().Length < 5) return await MessageValidateCampo06("AU03");
            if (AuditCreateUser.Trim().Length > 15) return await MessageValidateCampo06("AU04");
            if (!Regex.IsMatch(AuditCreateUser.Trim(), RegExpText)) return await MessageValidateCampo06("AU05");

            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> ValidationAuditCreateDate1(string AuditCreateDate)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(AuditCreateDate)) return await MessageValidateCampo07("AD01");
            if (string.IsNullOrWhiteSpace(AuditCreateDate)) return await MessageValidateCampo07("AD02");
            if (AuditCreateDate.Trim().Length < 5) return await MessageValidateCampo07("AD03");
            if (AuditCreateDate.Trim().Length > 15) return await MessageValidateCampo07("AD04");
            if (!Regex.IsMatch(AuditCreateDate.Trim(), RegExpText)) return await MessageValidateCampo07("AD05");

            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }


       

        //************************************************************************************************


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

        // Url
        private async Task<DataItem> MessageValidateCampo03(string code)
        {
            DataItem lista = new DataItem();

            switch (code)
            {
                case "U01":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo Url no puede estar vacio"
                    };
                    break;
                case "U02":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo Url no puede tener espacios en blanco"
                    };
                    break;
                case "U03":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo Url debe tener al menos 6 caracteres"
                    };
                    break;
                case "U04":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo Url no puede mayor que 15 digitos"
                    };
                    break;
                case "U05":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo Url no cumple con los requisitos (,)"
                    };
                    break;
                default:
                    break;
            }
            return await Task.Run(() => lista);
        }

        // FatherId
        private async Task<DataItem> MessageValidateCampo04(string code)
        {
            DataItem lista = new DataItem();

            switch (code)
            {
                case "F01":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo FatherId no puede estar vacio"
                    };
                    break;
                case "F02":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo FatherId no puede tener espacios en blanco"
                    };
                    break;
                case "F03":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo FatherId debe tener al menos 6 caracteres"
                    };
                    break;
                case "F04":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo FatherId no puede mayor que 15 digitos"
                    };
                    break;
                case "F05":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo FatherId no cumple con los requisitos (,)"
                    };
                    break;
                default:
                    break;
            }
            return await Task.Run(() => lista);
        }

        // State 
        private async Task<DataItem> MessageValidateCampo05(string code)
        {
            DataItem lista = new DataItem();

            switch (code)
            {
                case "S01":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo State  no puede estar vacio"
                    };
                    break;
                case "S02":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo State  no puede tener espacios en blanco"
                    };
                    break;
                case "S03":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo State debe tener al menos 6 caracteres"
                    };
                    break;
                case "S04":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo State  no puede mayor que 15 digitos"
                    };
                    break;
                case "S05":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo State  no cumple con los requisitos (,)"
                    };
                    break;
                default:
                    break;
            }
            return await Task.Run(() => lista);
        }

        // AuditCreateUser
        private async Task<DataItem> MessageValidateCampo06(string code)
        {
            DataItem lista = new DataItem();

            switch (code)
            {
                case "AU01":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo AuditCreateUser  no puede estar vacio"
                    };
                    break;
                case "AC02":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo AuditCreateUser  no puede tener espacios en blanco"
                    };
                    break;
                case "AC03":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo AuditCreateUser debe tener al menos 6 caracteres"
                    };
                    break;
                case "AC04":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo AuditCreateUser  no puede mayor que 15 digitos"
                    };
                    break;
                case "AC05":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo State  no cumple con los requisitos (,)"
                    };
                    break;
                default:
                    break;
            }
            return await Task.Run(() => lista);
        }

        // AuditCreateDate
        private async Task<DataItem> MessageValidateCampo07(string code)
        {
            DataItem lista = new DataItem();

            switch (code)
            {
                case "AD01":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo AuditCreateDate  no puede estar vacio"
                    };
                    break;
                case "AD02":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo AuditCreateDate  no puede tener espacios en blanco"
                    };
                    break;
                case "AD03":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo AuditCreateDate debe tener al menos 6 caracteres"
                    };
                    break;
                case "AD04":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo AuditCreateDate  no puede mayor que 15 digitos"
                    };
                    break;
                case "AD05":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "Campo AuditCreateDate  no cumple con los requisitos (,)"
                    };
                    break;
                default:
                    break;
            }
            return await Task.Run(() => lista);
        }



    }
}



