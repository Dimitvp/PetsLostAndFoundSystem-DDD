namespace PetsLostAndFoundSystem.Web.Features
{
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Reporting.Reporters.Commands.Edit;
    using Application.Reporting.Reporters.Queries.Details;
    using Microsoft.AspNetCore.Mvc;

    public class ReportersController : ApiController
    {
        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<ReporterDetailsOutputModel>> Details(
           [FromRoute] ReporterDetailsQuery query)
           => await this.Send(query);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditReporterCommand command)
            => await this.Send(command.SetId(id));
    }
}
