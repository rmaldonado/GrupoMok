namespace Application.DTO.AppSettings
{
    public class ConfigController
    {
        public bool Flag_WriteRequest { get; set; }
        public bool Flag_WriteResponse { get; set; }
        public bool Flag_WriteToken { get; set; }
        public bool Flag_WriteResponse_Config { get; set; }
        public bool Flag_EncryptFromFront { get; set; }
        public int Seconds_wait_to_front { get; set; }
        public string Vector { get; set; }
    }
}
