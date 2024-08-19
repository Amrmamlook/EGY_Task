﻿using Mediator;
using Microsoft.AspNetCore.Mvc;
using Planta_BackEnd.Mediator;
using Task_Test.Options.Response;

namespace Task_Test.Medatior.Query
{
    public record GetClientsQuery([FromQuery]int PageNumber,[FromQuery] int PageSize) :IRequest<PageList<ClientDto>>;
}
