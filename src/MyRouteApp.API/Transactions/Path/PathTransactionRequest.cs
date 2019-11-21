﻿using MediatR;
using MyRouteApp.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRouteApp.API.Transactions.Path
{
    public class PathTransactionRequest : IRequest<PathTransactionResponse>
    {
        public PathModel PathModel { get; set; }
    }
}
