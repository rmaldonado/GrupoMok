
using Application.DTO;
using Application.DTO.Request;
using Common;
using Domain.Entity;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Interface.ValidationInterface.User
{
    public class CompanysValidationsAplications: ICompanysValidationsAplications
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



        
            public async Task<Validation> ValidateCompanys(CompanyRequestCreateDto request)
            {
                DataItem messageValidation = new DataItem();

                Validation validation = new Validation
                {
                    Validate = true,
                    Message = Constants.OK
                };


                messageValidation = await ValidationCompanyNumber1(request.CompanyNumber);
                if (!messageValidation.Value.Equals(Constants.OK))
                {
                    validation.Code = messageValidation.Name;
                    validation.Validate = false;
                    validation.Message = messageValidation.Value;
                    return validation;
                }

                messageValidation = await ValidationCompanyName1(request.CompanyName);

                if (!messageValidation.Value.Equals(Constants.OK))
                {
                    validation.Code = messageValidation.Name;
                    validation.Validate = false;
                    validation.Message = messageValidation.Value;
                    return validation;
                }

                messageValidation = await ValidationContactName1(request.ContactName);

                if (!messageValidation.Value.Equals(Constants.OK))
                {
                    validation.Code = messageValidation.Name;
                    validation.Validate = false;
                    validation.Message = messageValidation.Value;
                    return validation;
                }

                messageValidation = await ValidationContactPhone1(request.ContactPhone);

                if (!messageValidation.Value.Equals(Constants.OK))
                {
                    validation.Code = messageValidation.Name;
                    validation.Validate = false;
                    validation.Message = messageValidation.Value;
                    return validation;
                }

                messageValidation = await ValidationContactEmail1(request.ContactEmail);

                if (!messageValidation.Value.Equals(Constants.OK))
                {
                    validation.Code = messageValidation.Name;
                    validation.Validate = false;
                    validation.Message = messageValidation.Value;
                    return validation;
                }




                return await Task.Run(() => validation);
            }

            public async Task<Validation> ValidateCompanysEdit(CompanyRequestEditDto request)
            {
                DataItem messageValidation = new DataItem();

                Validation validation = new Validation
                {
                    Validate = true,
                    Message = Constants.OK
                };


                messageValidation = await ValidationCompanyNumber2(request.CompanyNumber);
                if (!messageValidation.Value.Equals(Constants.OK))
                {
                    validation.Code = messageValidation.Name;
                    validation.Validate = false;
                    validation.Message = messageValidation.Value;
                    return validation;
                }

                messageValidation = await ValidationCompanyName2(request.CompanyName);

                if (!messageValidation.Value.Equals(Constants.OK))
                {
                    validation.Code = messageValidation.Name;
                    validation.Validate = false;
                    validation.Message = messageValidation.Value;
                    return validation;
                }

                messageValidation = await ValidationContactName2(request.ContactName);

                if (!messageValidation.Value.Equals(Constants.OK))
                {
                    validation.Code = messageValidation.Name;
                    validation.Validate = false;
                    validation.Message = messageValidation.Value;
                    return validation;
                }

                messageValidation = await ValidationContactPhone2(request.ContactPhone);

                if (!messageValidation.Value.Equals(Constants.OK))
                {
                    validation.Code = messageValidation.Name;
                    validation.Validate = false;
                    validation.Message = messageValidation.Value;
                    return validation;
                }

                messageValidation = await ValidationContactEmail2(request.ContactEmail);

                if (!messageValidation.Value.Equals(Constants.OK))
                {
                    validation.Code = messageValidation.Name;
                    validation.Validate = false;
                    validation.Message = messageValidation.Value;
                    return validation;
                }




                return await Task.Run(() => validation);
            }


            //objeto 01 Create 

            private async Task<DataItem> ValidationCompanyNumber1(string CompanyNumber)
            {
                DataItem lista = new DataItem();
                if (string.IsNullOrEmpty(CompanyNumber)) return await MessageValidateCampo01("N01");
                if (string.IsNullOrWhiteSpace(CompanyNumber)) return await MessageValidateCampo01("N02");
                if (CompanyNumber.Trim().Length < 5) return await MessageValidateCampo01("N03");
                if (CompanyNumber.Trim().Length > 15) return await MessageValidateCampo01("N04");
                if (!Regex.IsMatch(CompanyNumber.Trim(), RegExpText)) return await MessageValidateCampo01("N05");

                lista = new DataItem { Name = "00", Value = Constants.OK };
                return await Task.Run(() => lista);
            }

            private async Task<DataItem> ValidationCompanyName1(string CompanyName)
            {
                DataItem lista = new DataItem();
                if (string.IsNullOrEmpty(CompanyName)) return await MessageValidateCampo02("I01");
                if (string.IsNullOrWhiteSpace(CompanyName)) return await MessageValidateCampo02("I02");
                if (CompanyName.Trim().Length < 5) return await MessageValidateCampo02("I03");
                if (CompanyName.Trim().Length > 15) return await MessageValidateCampo02("I04");
                if (!Regex.IsMatch(CompanyName.Trim(), RegExpText)) return await MessageValidateCampo02("I05");

                lista = new DataItem { Name = "00", Value = Constants.OK };
                return await Task.Run(() => lista);
            }

            private async Task<DataItem> ValidationContactName1(string ContactName)
            {
                DataItem lista = new DataItem();
                if (string.IsNullOrEmpty(ContactName)) return await MessageValidateCampo03("U01");
                if (string.IsNullOrWhiteSpace(ContactName)) return await MessageValidateCampo03("U02");
                if (ContactName.Trim().Length < 5) return await MessageValidateCampo03("U03");
                if (ContactName.Trim().Length > 15) return await MessageValidateCampo03("U04");
                if (!Regex.IsMatch(ContactName.Trim(), RegExpText)) return await MessageValidateCampo03("U05");

                lista = new DataItem { Name = "00", Value = Constants.OK };
                return await Task.Run(() => lista);
            }

            private async Task<DataItem> ValidationContactPhone1(string ContactPhone)
            {
                DataItem lista = new DataItem();
                if (string.IsNullOrEmpty(ContactPhone)) return await MessageValidateCampo04("F01");
                if (string.IsNullOrWhiteSpace(ContactPhone)) return await MessageValidateCampo04("F02");
                if (ContactPhone.Trim().Length < 5) return await MessageValidateCampo04("F03");
                if (ContactPhone.Trim().Length > 15) return await MessageValidateCampo04("F04");
                if (!Regex.IsMatch(ContactPhone.Trim(), RegExpText)) return await MessageValidateCampo04("F05");

                lista = new DataItem { Name = "00", Value = Constants.OK };
                return await Task.Run(() => lista);
            }

            private async Task<DataItem> ValidationContactEmail1(string ContactEmail)
            {
                DataItem lista = new DataItem();
                if (string.IsNullOrEmpty(ContactEmail)) return await MessageValidateCampo05("S01");
                if (string.IsNullOrWhiteSpace(ContactEmail)) return await MessageValidateCampo05("S02");
                if (ContactEmail.Trim().Length < 5) return await MessageValidateCampo05("S03");
                if (ContactEmail.Trim().Length > 15) return await MessageValidateCampo05("S04");
                if (!Regex.IsMatch(ContactEmail.Trim(), RegExpText)) return await MessageValidateCampo05("S05");

                lista = new DataItem { Name = "00", Value = Constants.OK };
                return await Task.Run(() => lista);
            }

            //objeto 02 Create 

            private async Task<DataItem> ValidationCompanyNumber2(string CompanyNumber)
            {
                DataItem lista = new DataItem();
                if (string.IsNullOrEmpty(CompanyNumber)) return await MessageValidateCampo01("N01");
                if (string.IsNullOrWhiteSpace(CompanyNumber)) return await MessageValidateCampo01("N02");
                if (CompanyNumber.Trim().Length < 5) return await MessageValidateCampo01("N03");
                if (CompanyNumber.Trim().Length > 15) return await MessageValidateCampo01("N04");
                if (!Regex.IsMatch(CompanyNumber.Trim(), RegExpText)) return await MessageValidateCampo01("N05");

                lista = new DataItem { Name = "00", Value = Constants.OK };
                return await Task.Run(() => lista);
            }

            private async Task<DataItem> ValidationCompanyName2(string CompanyName)
            {
                DataItem lista = new DataItem();
                if (string.IsNullOrEmpty(CompanyName)) return await MessageValidateCampo02("I01");
                if (string.IsNullOrWhiteSpace(CompanyName)) return await MessageValidateCampo02("I02");
                if (CompanyName.Trim().Length < 5) return await MessageValidateCampo02("I03");
                if (CompanyName.Trim().Length > 15) return await MessageValidateCampo02("I04");
                if (!Regex.IsMatch(CompanyName.Trim(), RegExpText)) return await MessageValidateCampo02("I05");

                lista = new DataItem { Name = "00", Value = Constants.OK };
                return await Task.Run(() => lista);
            }

            private async Task<DataItem> ValidationContactName2(string ContactName)
            {
                DataItem lista = new DataItem();
                if (string.IsNullOrEmpty(ContactName)) return await MessageValidateCampo03("U01");
                if (string.IsNullOrWhiteSpace(ContactName)) return await MessageValidateCampo03("U02");
                if (ContactName.Trim().Length < 5) return await MessageValidateCampo03("U03");
                if (ContactName.Trim().Length > 15) return await MessageValidateCampo03("U04");
                if (!Regex.IsMatch(ContactName.Trim(), RegExpText)) return await MessageValidateCampo03("U05");

                lista = new DataItem { Name = "00", Value = Constants.OK };
                return await Task.Run(() => lista);
            }

            private async Task<DataItem> ValidationContactPhone2(string ContactPhone)
            {
                DataItem lista = new DataItem();
                if (string.IsNullOrEmpty(ContactPhone)) return await MessageValidateCampo04("F01");
                if (string.IsNullOrWhiteSpace(ContactPhone)) return await MessageValidateCampo04("F02");
                if (ContactPhone.Trim().Length < 5) return await MessageValidateCampo04("F03");
                if (ContactPhone.Trim().Length > 15) return await MessageValidateCampo04("F04");
                if (!Regex.IsMatch(ContactPhone.Trim(), RegExpText)) return await MessageValidateCampo04("F05");

                lista = new DataItem { Name = "00", Value = Constants.OK };
                return await Task.Run(() => lista);
            }

            private async Task<DataItem> ValidationContactEmail2(string ContactEmail)
            {
                DataItem lista = new DataItem();
                if (string.IsNullOrEmpty(ContactEmail)) return await MessageValidateCampo05("S01");
                if (string.IsNullOrWhiteSpace(ContactEmail)) return await MessageValidateCampo05("S02");
                if (ContactEmail.Trim().Length < 5) return await MessageValidateCampo05("S03");
                if (ContactEmail.Trim().Length > 15) return await MessageValidateCampo05("S04");
                if (!Regex.IsMatch(ContactEmail.Trim(), RegExpText)) return await MessageValidateCampo05("S05");

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



        }
    }


