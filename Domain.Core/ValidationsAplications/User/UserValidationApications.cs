using Application.DTO;
using Application.DTO.Request;

using Common;
using Domain.Entity;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Interface.ValidationInterface.User
{
    public class UserValidationApications : IUserValidationInterface
    {
        const string RegExpAlphanumeric = @"^[a-zA-Z0-9]+$";
        const string RegExpPassword = @"^(?=.*\d)(?=.*[az])(?=.*[AZ])(?!.*\s).{8,15}$";
        const string RegExpText = @"^[a-zA-Z]+$";
        const string RegExpNumeric = @"^[0-9]+$";
        const string RegExpDecimal = @"^\d+(\.\d{1,2})?$";
        const string RegExpEmail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        const string RegExprHoraFecha = @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|[2-9][0-9])\d\d$";

        //Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        //-Debe tener al menos 8 caracteres
        const string RegExpMayorCaracteres = @"^.*(?=.{8,})(?=.*\\d)";
        //-Debe contener al menos una letra minúscula,
        const string RegExpMinuscula = @"(?=.*[a-z])";
        //-Una letra mayúscula,
        const string RegExpMayuscula = @"(?=.*[A-Z])";
        //-Un dígito y un carácter especial
        const string RegExpPasswordDigitoCaracter = @"(?=.*[@#$%^&+=]).*$";


        public async Task<Validation> ValidateUserCreate(UserRequestCreate request)
        {
            DataItem messageValidation = new DataItem();

            Validation validation = new Validation
            {
                Validate = true,
                Message = Constants.OK
            };


            messageValidation = await ValidationName(request.Name);
            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }

            messageValidation = await ValidationFirstLastName(request.FirstLastName);
            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }

            messageValidation = await ValidationDocumentType(request.DocumentType.ToString());
            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }

            messageValidation = await ValidationdocumentNumber(request.DocumentNumber);
            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }

            //messageValidation = await ValidationUserName(request.UserName);
            //if (!messageValidation.Value.Equals(Constants.OK))
            //{
            //    validation.Code = messageValidation.Name;
            //    validation.Validate = false;
            //    validation.Message = messageValidation.Value;
            //    return validation;
            //}

            messageValidation = await Validationpassword(request.Password);
            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }

            messageValidation = await Validationemail(request.Email);
            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }

            messageValidation = await ValidationKeyPublic(request.PublicKey);
            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }

            messageValidation = await Validationstate(request.State.ToString());
            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }

            messageValidation = await ValidationauditCreateUser(request.AuditCreateUser.ToString());
            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }

            messageValidation = await ValidationauditCreateDate(request.AuditCreateDate.ToString());
            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }


            return await Task.Run(() => validation);
        }


        //********  Logica Objeto 01 *******//


        private async Task<DataItem> ValidationName(string Name)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(Name)) return await MessageValidationName("N01");
            if (string.IsNullOrWhiteSpace(Name)) return await MessageValidationName("N02");
            if (Name.Trim().Length < 5) return await MessageValidationName("N03");
            if (Name.Trim().Length > 15) return await MessageValidationName("N04");

            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> ValidationFirstLastName(string FirstLastName)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(FirstLastName)) return await MessageValidationLasName("MC1");
            if (string.IsNullOrWhiteSpace(FirstLastName)) return await MessageValidationLasName("MC2");
            if (FirstLastName.Trim().Length < 5) return await MessageValidationLasName("MC3");
            if (FirstLastName.Trim().Length > 15) return await MessageValidationLasName("MC4");
            if (!Regex.IsMatch(FirstLastName.Trim(), RegExpText)) return await MessageValidationLasName("MC5");

            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> ValidationDocumentType(string documentType)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(documentType)) return await MessageValidationDocumentType("D01");
            if (string.IsNullOrWhiteSpace(documentType)) return await MessageValidationDocumentType("D02");
            if (documentType.Trim().Length !=1) return await MessageValidationDocumentType("D03");

            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> ValidationdocumentNumber(string documentNumber)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(documentNumber)) return await MessageValidationDocumentNumber("DN01");
            if (string.IsNullOrWhiteSpace(documentNumber)) return await MessageValidationDocumentNumber("DN02");
            if (documentNumber.Trim().Length < 8) return await MessageValidationDocumentNumber("DN03");
            if (documentNumber.Trim().Length > 15) return await MessageValidationDocumentNumber("DN04");
            if (!Regex.IsMatch(documentNumber.Trim(), RegExpNumeric)) return await MessageValidationDocumentNumber("DN05");


            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> ValidationUserName(string UserName)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(UserName)) return await MessageValidationUserName("U01");
            if (string.IsNullOrWhiteSpace(UserName)) return await MessageValidationUserName("U02");
            if (UserName.Trim().Length < 5) return await MessageValidationUserName("U03");
            if (UserName.Trim().Length > 15) return await MessageValidationUserName("U04");
            if (!Regex.IsMatch(UserName.Trim(), RegExpAlphanumeric)) return await MessageValidationUserName("U05");

            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> Validationpassword(string password)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(password)) return await MessageValidationpassword("P01");
            if (string.IsNullOrWhiteSpace(password)) return await MessageValidationpassword("P02");
            if (password.Trim().Length < 6) return await MessageValidationpassword("P03");
            if (password.Trim().Length > 15) return await MessageValidationpassword("P04");
            //if (!Regex.IsMatch(password.Trim(), RegExpPasswordDigitoCaracter)) return await MessageValidationpassword("P05");

            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> Validationemail(string email)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(email)) return await MessageValidationemail("E01");
            if (string.IsNullOrWhiteSpace(email)) return await MessageValidationemail("E02");

            if (email.Trim().Length < 5) return await MessageValidationemail("E03");
            if (email.Trim().Length > 20) return await MessageValidationemail("E04");
            if (!Regex.IsMatch(email.Trim(), RegExpPasswordDigitoCaracter)) return await MessageValidationemail("E05");


            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> ValidationKeyPublic(string KeyPublic)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(KeyPublic)) return await MessageValidationKeyPublic("K01");
            if (string.IsNullOrWhiteSpace(KeyPublic)) return await MessageValidationKeyPublic("K02");

            if (KeyPublic.Trim().Length < 16) return await MessageValidationKeyPublic("K03");
            if (KeyPublic.Trim().Length > 400) return await MessageValidationKeyPublic("K04");
            if (!Regex.IsMatch(KeyPublic.Trim(), RegExpAlphanumeric)) return await MessageValidationKeyPublic("K05");


            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> Validationstate(string state)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(state)) return await MessageValidationstate("ST01");
            if (string.IsNullOrWhiteSpace(state)) return await MessageValidationstate("ST02");

            if (state.Trim().Length !=1) return await MessageValidationstate("ST03");           

            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> ValidationauditCreateUser(string auditCreateUser)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(auditCreateUser)) return await MessageValidationauditCreateUser("AU01");
            if (string.IsNullOrWhiteSpace(auditCreateUser)) return await MessageValidationauditCreateUser("AU02");
            if (auditCreateUser.Trim().Length !=1) return await MessageValidationauditCreateUser("AU03");

            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> ValidationauditCreateDate(string auditCreateUser)
        {
            DataItem lista = new DataItem();
            if (string.IsNullOrEmpty(auditCreateUser)) return await MessageValidationauditCreateDate("AD01");
            if (string.IsNullOrWhiteSpace(auditCreateUser)) return await MessageValidationauditCreateDate("AD02");
            if (auditCreateUser.Trim().Length < 5) return await MessageValidationauditCreateDate("AD03");
            if (auditCreateUser.Trim().Length > 30) return await MessageValidationauditCreateDate("AD04");
 
            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }



        //*******   Mensajes validacion ****//

        private async Task<DataItem> MessageValidationName(string code)
        {
            DataItem lista = new DataItem();

            switch (code)
            {
                case "N01":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo Name no puede estar vacio"
                    };
                    break;
                case "N02":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo Name no puede tener espacios en blanco"
                    };
                    break;
                case "N03":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo Name debe tener al menos 6 caracteres"
                    };
                    break;
                case "N04":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo Name no puede mayor que 15 digitos"
                    };
                    break;
                
                default:
                    break;
            }
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> MessageValidationLasName(string code)
        {
            DataItem lista = new DataItem();

            switch (code)
            {
                case "L01":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo LasName no puede estar vacio"
                    };
                    break;
                case "L02":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo LasName no puede tener espacios en blanco"
                    };
                    break;
                case "L03":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo LasName tener al menos 8 caracteres"
                    };
                    break;
                case "L04":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo LasName no puede mayor que 15 digitos"
                    };
                    break;
                case "L05":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo LasName no cumple con los requisitos (Debe tener al menos 10 caracteres,)"
                    };
                    break;
                default:
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "No, Configurado"
                    };
                    break;
            }
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> MessageValidationDocumentType(string code)
        {
            DataItem lista = new DataItem();

            switch (code)
            {
                case "D01":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo DocumentType no puede estar vacio"
                    };
                    break;
                case "D02":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo DocumentType no puede tener espacios en blanco"
                    };
                    break;
                case "D03":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo DocumentType no es el adecuado, intente de nuevo "
                    };
                    break;
                case "D04":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo DocumentType no puede mayor que 1 un digito"
                    };
                    break;
                default:
                    break;
            }
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> MessageValidationDocumentNumber(string code)
        {
            DataItem lista = new DataItem();

            switch (code)
            {
                case "DN01":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo DocumentNumber no puede estar vacio"
                    };
                    break;
                case "DN02":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo DocumentNumber no puede tener espacios en blanco"
                    };
                    break;
                case "DN03":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo DocumentNumber tener al menos 8 caracteres"
                    };
                    break;
                case "DN04":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo DocumentNumber no puede mayor que 15 digitos"
                    };
                    break;
                case "DN05":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo DocumentNumber no cumple con los requisitos (Debe tener al menos 10 caracteres,)"
                    };
                    break;
                default:
                    break;
            }
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> MessageValidationUserName(string code)
        {
            DataItem lista = new DataItem();

            switch (code)
            {
                case "U01":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo UserName no puede estar vacio"
                    };
                    break;
                case "U02":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo UserName no puede tener espacios en blanco"
                    };
                    break;
                case "U03":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo UserName tener al menos 8 caracteres"
                    };
                    break;
                case "U04":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo UserName no puede mayor que 15 digitos"
                    };
                    break;
                case "U05":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo UserName no cumple con los requisitos (Debe tener al menos 10 caracteres,)"
                    };
                    break;
                default:
                    break;
            }
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> MessageValidationpassword(string code)
        {
            DataItem lista = new DataItem();

            switch (code)
            {
                case "P01":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo password no puede estar vacio"
                    };
                    break;
                case "P02":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo password no puede tener espacios en blanco"
                    };
                    break;
                case "P03":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo password tener al menos 8 caracteres"
                    };
                    break;
                case "P04":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo password no puede mayor que 15 digitos"
                    };
                    break;
                case "P05":
                    lista = new DataItem
                    {
                        Name = "P05",
                        Value = "El Campo password no cumple con los requisitos (Debe tener al menos 10 caracteres,)"
                    };
                    break;
                default:
                    break;
            }
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> MessageValidationemail(string code)
        {
            DataItem lista = new DataItem();

            switch (code)
            {
                case "E01":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo email no puede estar vacio"
                    };
                    break;
                case "E02":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo email no puede tener espacios en blanco"
                    };
                    break;
                case "E03":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo email debe tener al menos 9 caracteres"
                    };
                    break;
                case "E04":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo email no puede mayor que 20 digitos"
                    };
                    break;
                case "E05":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo email no cumple con los requisitos (Debe tener al menos 9 caracteres,)"
                    };
                    break;
                default:
                    break;
            }
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> MessageValidationKeyPublic(string code)
        {
            DataItem lista = new DataItem();

            switch (code)
            {
                case "K01":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo KeyPublic no puede estar vacio"
                    };
                    break;
                case "K02":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo KeyPublic no puede tener espacios en blanco"
                    };
                    break;
                case "K03":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo KeyPublic debe tener al menos 16 caracteres"
                    };
                    break;
                case "K04":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo KeyPublic no puede ser mayor que 400 digitos"
                    };
                    break;
                case "K05":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo KeyPublic no cumple con los requisitos (Debe tener al menos 16 caracteres,)"
                    };
                    break;
                default:
                    break;
            }
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> MessageValidationstate(string code)
        {
            DataItem lista = new DataItem();

            switch (code)
            {
                case "ST01":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo state no puede estar vacio"
                    };
                    break;
                case "ST02":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo state no puede tener espacios en blanco"
                    };
                    break;
                case "ST03":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo state no es el adecuado, intente de nuevo"
                    };
                    break;
                
                default:
                    break;
            }
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> MessageValidationauditCreateUser(string code)
        {
            DataItem lista = new DataItem();

            switch (code)
            {
                case "AU01":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo auditCreateUser no puede estar vacio"
                    };
                    break;
                case "AU02":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo auditCreateUser no puede tener espacios en blanco"
                    };
                    break;
                case "AU03":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo DocumentType no es el adecuado, intente de nuevo"
                    };
                    break;
                case "AU04":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo auditCreateUser no puede mayor que 1 un digito"
                    };
                    break;
                default:
                    break;
            }
            return await Task.Run(() => lista);
        }

        private async Task<DataItem> MessageValidationauditCreateDate(string code)
        {
            DataItem lista = new DataItem();

            switch (code)
            {
                case "AD01":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo auditCreateDate no puede estar vacio"
                    };
                    break;
                case "AD02":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo auditCreateDate no puede tener espacios en blanco"
                    };
                    break;
                case "AD03":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo auditCreateDate debe tener al menos 10 caracteres"
                    };
                    break;
                case "AD04":
                    lista = new DataItem
                    {
                        Name = "99",
                        Value = "El Campo auditCreateDate no puede mayor que 30 digitos"
                    };
                    break;
            
                default:
                    break;
            }
            return await Task.Run(() => lista);
        }


    }
}