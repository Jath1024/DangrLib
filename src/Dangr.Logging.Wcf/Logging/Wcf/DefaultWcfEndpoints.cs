// -----------------------------------------------------------------------
//  <copyright file="DefaultWcfEndpoints.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Logging.Wcf
{
    using System;
    using System.ServiceModel;

    /// <summary>
    ///     Defines constants to use as the default WCF endpoints in the 
    ///     <see cref="WcfLogService" />.
    /// </summary>
    public static class DefaultWcfEndpoints
    {
        /// <summary>
        ///     The default HTTP service name.
        /// </summary>
        public const string DefaultHttpServiceName = "HttpService";

        /// <summary>
        ///     Gets the HTTP URI.
        /// </summary>
        /// <param name="ip"> The ip. </param>
        /// <param name="port"> The port. </param>
        /// <returns> </returns>
        public static Uri GetHttpUri(string ip = "localhost", int port = 8185)
        {
            return new Uri($@"http://{ip}:{port}/DLogger");
        }

        /// <summary>
        ///     Gets the HTTP endpoint address.
        /// </summary>
        /// <param name="ip"> The ip. </param>
        /// <param name="port"> The port. </param>
        /// <param name="serviceName"> Name of the service. </param>
        /// <returns> </returns>
        public static EndpointAddress GetHttpEndpointAddress(
            string ip = "localhost",
            int port = 8185,
            string serviceName = DefaultWcfEndpoints.DefaultHttpServiceName)
        {
            return new EndpointAddress($"{DefaultWcfEndpoints.GetHttpUri(ip, port)}/{serviceName}");
        }

        /// <summary>
        ///     The default TCP service name
        /// </summary>
        public const string DefaultTcpServiceName = "NetTcpService";

        /// <summary>
        ///     Gets the net TCP URI.
        /// </summary>
        /// <param name="ip"> The ip. </param>
        /// <param name="port"> The port. </param>
        /// <returns> </returns>
        public static Uri GetNetTcpUri(string ip = "localhost", int port = 8186)
        {
            return new Uri($@"net.tcp://{ip}:{port}/DLogger");
        }

        /// <summary>
        ///     Gets the net TCP endpoint address.
        /// </summary>
        /// <param name="ip"> The ip. </param>
        /// <param name="port"> The port. </param>
        /// <param name="serviceName"> Name of the service. </param>
        /// <returns> </returns>
        public static EndpointAddress GetNetTcpEndpointAddress(
            string ip = "localhost",
            int port = 8186,
            string serviceName = DefaultWcfEndpoints.DefaultTcpServiceName)
        {
            return new EndpointAddress($"{DefaultWcfEndpoints.GetNetTcpUri(ip, port)}/{serviceName}");
        }

        /// <summary>
        ///     The default named pipe service name
        /// </summary>
        public const string DefaultNamedPipeServiceName = "NetPipeService";

        /// <summary>
        ///     Gets the net named pipe URI.
        /// </summary>
        /// <param name="ip"> The ip. </param>
        /// <returns> </returns>
        public static Uri GetNetNamedPipeUri(string ip = "localhost")
        {
            return new Uri($@"net.pipe://{ip}/DLogger");
        }

        /// <summary>
        ///     Gets the net named pipe endpoint address.
        /// </summary>
        /// <param name="ip"> The ip. </param>
        /// <param name="serviceName"> Name of the service. </param>
        /// <returns> </returns>
        public static EndpointAddress GetNetNamedPipeEndpointAddress(
            string ip = "localhost",
            string serviceName = DefaultWcfEndpoints.DefaultNamedPipeServiceName)
        {
            return new EndpointAddress($"{DefaultWcfEndpoints.GetNetNamedPipeUri(ip)}/{serviceName}");
        }

        /// <summary>
        ///     The default MSMQ service name
        /// </summary>
        public const string DefaultMsmqServiceName = "MsmqService";

        /// <summary>
        ///     Gets the MSMQ URI.
        /// </summary>
        /// <param name="ip"> The ip. </param>
        /// <returns> </returns>
        public static Uri GetMsmqUri(string ip = "localhost")
        {
            return new Uri($@"net.msmq://{ip}/private/DLogger");
        }

        /// <summary>
        ///     Gets the MSMQ endpoint address.
        /// </summary>
        /// <param name="ip"> The ip. </param>
        /// <param name="serviceName"> Name of the service. </param>
        /// <returns> </returns>
        public static EndpointAddress GetMsmqEndpointAddress(
            string ip = "localhost",
            string serviceName = DefaultWcfEndpoints.DefaultMsmqServiceName)
        {
            return new EndpointAddress($"{DefaultWcfEndpoints.GetMsmqUri(ip)}/{serviceName}");
        }
    }
}