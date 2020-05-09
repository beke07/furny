﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Models;
using System;

namespace Furny.Models
{
    public interface IMongoEntityBase : IDocument<ObjectId>
    {
        public DateTime CreatedOn { get; }

        public bool IsDeleted { get; set; }
    }

    public class MongoEntityBase : IMongoEntityBase
    {
        public MongoEntityBase()
        {
            Id = ObjectId.GenerateNewId();
            CreatedOn = Id.CreationTime;
        }

        public MongoEntityBase(string id)
        {
            if (ObjectId.TryParse(id, out ObjectId _id))
            {
                Id = _id;
                CreatedOn = _id.CreationTime;
            }

            throw new Exception("Id nem lehet üres!");
        }

        public DateTime CreatedOn { get; }

        public bool IsDeleted { get; set; }

        public ObjectId Id { get; set; }

        public int Version { get; set; }
    }
}
