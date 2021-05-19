﻿using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataProvider.Entities
{
    public class Track
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public long Id { get; set; }
        public DateTime Time { get; set; }
        public int? SegmentId { get; set; }
        public int? Speed { get; set; }
        public string Street { get; set; }
        public string Direction { get; set; }
        public string FromStreet { get; set; }
        public string ToStreet { get; set; }
        public double? Length { get; set; }
        public string StreetHeading { get; set; }
        public string Comments { get; set; }
        public int? BusCount { get; set; }
        public int? MessageCount { get; set; }
        public int? Hour { get; set; }
        public int? DayOfWeek { get; set; }
        public int? Month { get; set; }
        public string RecordId { get; set; }
        public string StartLat { get; set; }
        public string StartLng { get; set; }
        public string EndLat { get; set; }
        public string EndLng { get; set; }
        public int? CommunityAreas { get; set; }
        public int? ZipCodes { get; set; }
        public int? Wards { get; set; }
    }
}
