using Microsoft.AspNetCore.Http;
using SOSUrbano.Domain.Interfaces.Services.FileService;

namespace SOSUrbano.Infra.CrossCutting.Extensions.Services.FileService
{
    public class FileService : IFileService
    {
        /*
         IFormFile é uma interface que trata o arquivo enviado pelo usuário
         */
        public async Task<List<string>> SavePhotosAsync(List<IFormFile> files)
        {
            var paths = new List<string>();

            bool unacceptablePath = false;

            string[] extensions = [".jpg", ".png", ".jpeg"];

            foreach(IFormFile file in files)
            {
                var extension = Path.GetExtension(file.FileName);

                if (!extensions.Contains(extension))
                    unacceptablePath = true;
            }
            
            if(unacceptablePath)
                throw new Exception("Extensões aceitas: .jpg, .png, .pjeg");

            foreach (IFormFile file in files)
            {
                /*
                 Path.GetExtension vai pegar o que estiver após o último ponto.
                Por exemplo: teste.testando.png, essa função vai retornar .png,
                pois pega o que vem após o último ponto.
                 */
                var extension = Path.GetExtension(file.FileName);
    
                var uniqueName = Guid.NewGuid() + extension;
                
                /*
                 Path.Combine vai fazer a junção de tudo o que for passado os
                separando em \, caso esteja no windows, e separando em /, caso 
                esteja no Mac
                 */
                var path = Path.Combine(
                    "wwwroot", 
                    "Images", 
                    "Incident", 
                    uniqueName);

                /*
                 new FileStream cria ou sobrescreve este arquivo no disco, 
                salvando no backend no caminho especificado na variável path,
                ou seja, vai criar um arquivo real na pasta definida no projeto.

                using var stream é o seguinte: quando usamos FileStream é aberto
                um canal de escrita de arquivo e este canal precisa ser fechado
                logo após seu uso para que não dê erro na requisição ou bloqueio
                no servidor, principalmente quando temos requisições simultâneas.
                Ao utilizar using var stream, este canal é fechado automaticamente
                quando a requisição for concluída quando o await finalizar mesmo
                se der erro no meio do processo.
                 */

                using var stream = new FileStream(path, FileMode.Create);

                /*
                 file.CopyToAsync vai fazer o seguinte: pega o arquivo que está
                sendo enviado no corpo da requisição e copia ele no caminho
                aberto para criação feito na variável stream.
                Ou seja, copia este arquivo físico no caminho ali porque eu vou
                usar essa imagem depois a partir desse caminho
                 */
                await file.CopyToAsync(stream);


                /*
                 E paths.Add estamos adicionando esse caminho na lista de string
                criado logo no início da função. Não podemos utiliza a variável
                path, pois o front não vai ter acesso a wwwroot, isso é particular
                do backend. Por isso, passamos o caminho que o front vai utilizar.
                 */
                paths.Add($"Images/Incident/{uniqueName}");
            }

            return paths;
        }
    }
}
