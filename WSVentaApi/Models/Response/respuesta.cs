namespace WSVentaApi.Models.Response
{
    public class respuesta
    {

        public int Exito { get; set; }
        public string Mensaje { get; set; }

        public object Data { get; set; }


       public respuesta()
        {
            this.Exito = 0;
        }
    }
}
