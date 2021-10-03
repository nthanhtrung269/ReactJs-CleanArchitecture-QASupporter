﻿using System;

namespace QASupporter.Domain.SharedKernel
{
    public class BaseRequestObject
    {
        public Guid? CorrelationId { get; set; }

        public Guid GetCorrelationId()
        {
            return CorrelationId != null && CorrelationId != Guid.Empty
                ? CorrelationId.Value
                : Guid.NewGuid();
        }
    }
}
