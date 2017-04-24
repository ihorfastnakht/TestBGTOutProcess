using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Microsoft.Toolkit.Uwp;

namespace TestBGTOutProcess
{
    public static class BackgroundTaskWrapper
    {
        public static void RegisterTasks()
        {
            var taskName = nameof(BackgroundComponent.TimeBackgroundTask);
            var taskEntryPoint = typeof(BackgroundComponent.TimeBackgroundTask).ToString();
            var trigger = new TimeTrigger(15, false);
            var condition = new SystemCondition(SystemConditionType.InternetAvailable);

            BackgroundTaskHelper.Register(taskName, taskEntryPoint, trigger, true, conditions: condition);
        }
    }
}
