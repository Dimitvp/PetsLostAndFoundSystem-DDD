namespace PetsLostAndFoundSystem.Web.Features
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Reporting.Reports.Commands.ChangeAprovel;
    using Application.Reporting.Reports.Commands.Create;
    using Application.Reporting.Reports.Commands.Delete;
    using Application.Reporting.Reports.Commands.Edit;
    using Application.Reporting.Reports.Queries.Details;
    using Application.Reporting.Reports.Queries.Mine;
    using Application.Reporting.Reports.Queries.Search;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ReportsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<SearchReportsOutputModel>> Search(
            [FromQuery] SearchReportsQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<ReportDetailsOutputModel>> Details(
            [FromRoute] ReportDetailsQuery query)
            => await this.Send(query);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateReportOutputModel>> Create(
            CreateReportCommand command)
            => await this.Send(command);

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditReportCommand command)
            => await this.Send(command.SetId(id));

        [HttpDelete]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Delete(
            [FromRoute] DeleteReportCommand command)
            => await this.Send(command);

        [HttpGet]
        [Authorize]
        [Route(nameof(Mine))]
        public async Task<ActionResult<MineReportsOutputModel>> Mine(
            [FromQuery] MineReportsQuery query)
            => await this.Send(query);

        [HttpPut]
        [Authorize]
        [Route(Id + PathSeparator + nameof(ChangeAprovel))]
        public async Task<ActionResult> ChangeAprovel(
            [FromRoute] ChangeAprovelCommand query)
            => await this.Send(query);
    }
}
