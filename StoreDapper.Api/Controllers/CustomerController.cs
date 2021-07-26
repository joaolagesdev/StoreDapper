using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StoreDapper.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using StoreDapper.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using StoreDapper.Domain.StoreContext.Entities;
using StoreDapper.Domain.StoreContext.Handlers;
using StoreDapper.Domain.StoreContext.Repositories;
using StoreDapper.Shared.Commands;

namespace StoreDapper.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/customers")]
        [ResponseCache(Duration = 15)]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        //{id: int} restrição de tipo
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.Get(id);
        }

        [HttpGet]
        [Route("v2/customers/{document}")]
        public GetCustomerQueryResult GetByDocument(Guid document)
        {
            return _repository.Get(document);
        }

        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/customers")]
        public ICommandResult Post([FromBody]CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("v1/customers/{id}")]
        public ICommandResult Put([FromBody]Customer command)
        {
            return null;
        }

        [HttpDelete]
        [Route("v1/customers{id}")]
        public string Delete()
        {
            return null;
        }
    }
}