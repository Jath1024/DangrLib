// -----------------------------------------------------------------------
//  <copyright file="TaskAttribute.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-04-24</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Annotation
{
    using System;

    /// <summary>
    /// Attribute used to link a task to a code element.
    /// </summary>
    /// <seealso cref="T:System.Attribute" />
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class TaskAttribute : Attribute
    {
        /// <summary>
        /// Gets the task identifier.
        /// </summary>
        public string TaskId { get; }

        /// <summary>
        /// Gets or sets the task description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskAttribute" /> class.
        /// </summary>
        /// <param name="taskId">The task identifier.</param>
        public TaskAttribute(string taskId)
        {
            this.TaskId = taskId;
        }
    }
}