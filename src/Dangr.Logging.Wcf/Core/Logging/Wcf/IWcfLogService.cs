// -----------------------------------------------------------------------
//  <copyright file="IWcfLogService.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Logging.Wcf
{
    using System.ServiceModel;
    using Dangr.Core.Logging;
    using Dangr.Internal.Logging.Wcf;

    /// <summary>
    /// Interface for a service that listens for connections from 
    /// <see cref="WcfLogClient" /> s and logs the messages to a designated 
    /// <see cref="LogService" /> .
    /// </summary>
    [ServiceContract(Namespace = "http://Dangr/Logging/2015/10")]
    public interface IWcfLogService
    {
        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        [OperationContract]
        void Log(LogEntry message);

        /// <summary>
        /// Logs a batch of messages.
        /// </summary>
        /// <param name="messages">The messages.</param>
        [OperationContract]
        void LogBatch(LogEntry[] messages);
    }
}