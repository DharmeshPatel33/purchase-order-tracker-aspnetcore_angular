﻿using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PurchaseOrderTracker.DAL;

namespace PurchaseOrderTracker.Web.Features.Api.Supplier
{
    public class Delete
    {
        public class Command : IRequest
        {
            [Required]
            public int? Id { get; set; }
        }

        public class CommandHandler : IAsyncRequestHandler<Command>
        {
            private readonly PoTrackerDbContext _context;

            public CommandHandler(PoTrackerDbContext context)
            {
                _context = context;
            }

            public async Task Handle(Command command)
            {
                _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
                var supplier = await _context.Supplier.SingleAsync(s => s.Id == command.Id);

                //TODO
                //if (!supplier.CanBeDeleted)
                //    throw new PurchaseOrderTrackerException("Supplier cannot be deleted");

                _context.Supplier.Remove(supplier);
                await _context.SaveChangesAsync();
            }
        }
    }
}