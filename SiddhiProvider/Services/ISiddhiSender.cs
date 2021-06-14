using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataProvider.Entities;

namespace SiddhiProvider.Services
{
    public interface ISiddhiSender
    {
        Task<string> SendData(Track track);
    }
}
