﻿namespace Blasco.Data.Models
{
    using MongoDB.Bson;

    public class Image
    {

        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        //[BsonRequired]
        public string FileName { get; set; } = null!;

        //[BsonRequired]
        public byte[] ContentImage { get; set; } = null!;

        //[BsonRequired]
        public string EntityCorrespondingId { get; set; } = null!;
    }
}
