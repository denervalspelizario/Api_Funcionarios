namespace WEB_API.ViewModel
{
    public class EmployeeViewModel
    {
        // Propriedades
        public string Name { get; set; }
        public int Age { get; set; }

        /*[2] propiedade adicionada posteriomente para receber Photo e
              todos os atributos de um arquivo como tipo de arquivo,
              tamanho e o arquivo de fato */
        public IFormFile Photo { get; set; }
    }
}
