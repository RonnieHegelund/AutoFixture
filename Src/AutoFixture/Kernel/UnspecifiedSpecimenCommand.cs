﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ploeh.AutoFixture.Kernel
{
    /// <summary>
    /// Encapsulates an operation without identifying any property or field.
    /// </summary>
    /// <typeparam name="T">The type of specimen.</typeparam>
    public class UnspecifiedSpecimenCommand<T> : ISpecifiedSpecimenCommand<T>
    {
        private readonly Action<T> action;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnspecifiedSpecimenCommand&lt;T&gt;"/>
        /// class.
        /// </summary>
        /// <param name="action">The action to perform on a specimen.</param>
        public UnspecifiedSpecimenCommand(Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            this.action = action;
        }

        /// <summary>
        /// Gets the action that can be performed on a specimen.
        /// </summary>
        public Action<T> Action
        {
            get { return this.action; }
        }

        #region ISpecifiedSpecimenCommand<T> Members

        /// <summary>
        /// Executes <see cref="Action"/> on the supplied specimen.
        /// </summary>
        /// <param name="specimen">The specimen on which the command is executed.</param>
        /// <param name="container">
        /// An <see cref="ISpecimenContainer"/> that can be used to resolve other requests. Not
        /// used.
        /// </param>
        public void Execute(T specimen, ISpecimenContainer container)
        {
            this.Action(specimen);
        }

        #endregion

        #region IRequestSpecification Members

        /// <summary>
        /// Evaluates a request for a specimen.
        /// </summary>
        /// <param name="request">The specimen request.</param>
        /// <returns>
        /// <see langword="false"/>.
        /// </returns>
        public bool IsSatisfiedBy(object request)
        {
            return false;
        }

        #endregion
    }
}