﻿using AutoMapper;
using ST.Application.Wrappers;
using ST.Contracts.Ticket;
using ST.Domain.Entities;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Tickets.Commands.UpdateTicket
{
    internal class UpdateTicketCommandHandler : ICommandHandler<UpdateTicketCommand, Result>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public UpdateTicketCommandHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }
        public async Task<Result> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticketExist = await _ticketRepository.GetByIdAsync(request.Id);
            if (ticketExist == null)
            {
                return Response.Fail("Khong ton tai ve trong he thong");
            }

            var updateTicket = _mapper.Map<TicketRequest, Ticket>(request.Request, ticketExist);

            try
            {
                await _ticketRepository.UpdateAsync(updateTicket);
                return Response.UpdateSuccessfully("Ticket");
            }
            catch (Exception ex)
            {
                return Response.UpdateFailed("Ticket");
            }
        }
    }
}