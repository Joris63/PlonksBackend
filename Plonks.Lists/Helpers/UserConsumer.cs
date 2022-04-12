﻿using MassTransit;
using Plonks.Lists.Services;
using Plonks.Shared.Entities;

namespace Plonks.Lists.Helpers
{
    public class UserConsumer : IConsumer<SharedUser>
    {
        private readonly IUserService _service;

        public UserConsumer(IUserService service)
        {
            _service = service;
        }
        public async Task Consume(ConsumeContext<SharedUser> context)
        {
            try
            {
                await _service.SaveUser(context.Message);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
            }
        }
    }
}
