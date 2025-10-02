using ClientsFlow.Application.UseCases.Clients.Delete;
using ClientsFlow.Application.UseCases.Clients.GetAll;
using ClientsFlow.Application.UseCases.Clients.GetById;
using ClientsFlow.Application.UseCases.Clients.Register;
using ClientsFlow.Application.UseCases.Clients.Update;
using ClientsFlow.Communication.Requests;
using ClientsFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ClientsFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> RegisterClients(
            [FromServices] IRegisterClientUseCase useCase,
            [FromBody] RequestClientJson request
            )
        {
            var response = await useCase.RegisterClient(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllClients([FromServices] IGetClientsUseCase useCase)
        {

            var response = await useCase.Execute();

            return Ok(response);

        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromServices] IGetClientByIdUseCase useCase,
            [FromRoute] long id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteClient([FromRoute]long id, 
            [FromServices] IDeleteClientUseCase useCase)
        {

            await useCase.Execute(id);

            return NoContent();
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromServices] IUpdateClientUseCase useCase,
            [FromRoute] long id,
            [FromBody] RequestClientJson request)
        {

            await useCase.Execute(id, request);

            return NoContent();

        }
    }
}


// Proximo passo:
//Criar uma entidade de usuarios, em que cada cliente estará vinculado a um usuario (advogado).
// Configurar migrations para o banco de dados;
//Configurar gitignore.
//Atualizar o projeto no github com todas as alterações.
// Fazer validações para o registro de usuario sem usar fluentvalidation
