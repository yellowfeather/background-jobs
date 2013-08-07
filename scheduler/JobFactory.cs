// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JobFactory.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   The job factory that uses the ServiceLocator to create a new job.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Scheduler
{
    using System;

    using Microsoft.Practices.ServiceLocation;

    using Quartz;
    using Quartz.Spi;

    /// <summary>
    /// The job factory that uses the ServiceLocator to create a new job.
    /// </summary>
    public class JobFactory : IJobFactory
    {
        /// <summary>
        /// Creates a new job.
        /// </summary>
        /// <param name="bundle">
        /// The bundle.
        /// </param>
        /// <param name="scheduler">
        /// The scheduler.
        /// </param>
        /// <returns>
        /// The <see cref="IJob"/>.
        /// </returns>
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                var type = bundle.JobDetail.JobType;
                var key = bundle.JobDetail.JobType.ToString();
                return ServiceLocator.Current.GetInstance(type, key) as IJob;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// The return job.
        /// </summary>
        /// <param name="job">
        /// The job.
        /// </param>
        public void ReturnJob(IJob job)
        {
            // do nothing
        }
    }
}