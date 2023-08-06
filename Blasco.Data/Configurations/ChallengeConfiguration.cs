﻿using Blasco.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Data.Configurations
{
    public class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
    {
        public void Configure(EntityTypeBuilder<Challenge> builder)
        {
            builder
               .Property(c => c.CreatedOn)
               .HasDefaultValueSql("GETDATE()");

            builder
               .Property(c => c.EndDate)
               .HasDefaultValueSql("DATEADD(month, +2, GETDATE())");

            builder
                .HasOne(c => c.Category)
                .WithMany(p => p.Challenges)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.CustomerCreatedChallenge)
                .WithMany(u=>u.Challenges)
                .HasForeignKey(c=>c.CustomerCreatedChallengeId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasData(this.GenerateChallenges());
        }
        private Challenge[] GenerateChallenges()
        {
            ICollection<Challenge> challenges = new HashSet<Challenge>();

            Challenge challenge;

            challenge = new Challenge()
            {
                Title = "Architectural Visions: Redesign Our Identity",
                Description = "Are you a creative mind with a flair for design? Put your artistic prowess to the test and join our exciting contest, \"Architectural Visions: Redesign Our Identity.\"\r\n\r\nAre you up for the challenge? Unleash your creativity and design a new logo that symbolizes the essence of Architecture, evoking elegance, forward-thinking concepts, and a seamless fusion of form and function.",
                CategoryId = 5,
                PriceToWin = 200,
                IsOnGoing = true
            };
            challenges.Add(challenge);

            challenge = new Challenge()
            {
                Title = "Capturing Nature's Wonders: A Photographic Odyssey",
                Description = "Calling all nature enthusiasts and photography enthusiasts alike! Embark on a visual journey of awe and wonder as we invite you to participate in our thrilling contest, \"Capturing Nature's Wonders: A Photographic Odyssey.\" Immerse yourself in the beauty of the natural world and showcase your talent by capturing the most mesmerizing moments in nature through your lens.",
                CategoryId = 10,
                PriceToWin = 200,
                IsOnGoing = true
            };
            challenges.Add(challenge);

            return challenges.ToArray();
        }
    }
}
