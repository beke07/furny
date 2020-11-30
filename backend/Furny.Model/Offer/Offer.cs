﻿using Furny.Common.Enums;
using Furny.Common.Models;
using System;
using System.Collections.Generic;

namespace Furny.Model
{
    public class Offer : MongoEntityBase
    {
        public Offer() : base()
        { }

        public Offer(string id) : base(id)
        { }

        public string PanelCutterId { get; set; }

        public string DesignerId { get; set; }

        public string FurnitureId { get; set; }

        public IList<OfferComponent> Components { get; set; }

        public long? Price { get; set; }

        public DateTime? Deadline { get; set; }

        public OfferState State { get; set; }
    }
}
