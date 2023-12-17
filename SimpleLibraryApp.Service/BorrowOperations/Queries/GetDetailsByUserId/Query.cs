﻿using MediatR;
using SimpleLibraryApp.Core.Response;

namespace SimpleLibraryApp.Service.BorrowOperations.Queries.GetDetailsByUserId;

public class Query : IRequest<GenericDataResponse<List<Dto>>>
{
    public int UserId { get; set; }
}
