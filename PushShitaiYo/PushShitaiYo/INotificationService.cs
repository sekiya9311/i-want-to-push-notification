using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PushShitaiYo
{
    public interface INotificationService
    {
        bool IsAvailable();

        void ChangeToAvailable();

        Task<string> GetTokenAsync();
    }
}
