using Blasco.Data.Models;
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
               .Property(p => p.CreatedOn)
               .HasDefaultValueSql("GETDATE()");

            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Challenges)
                .HasForeignKey(p => p.CategoryId)
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
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQt_6cdJdGcppF55kqefSCDtaPuH9CFyZx1ktsjy1AX5GhsO4hGDYnZXtExPtahHlQkpdg&usqp=CAU",
                Description = "Are you a creative mind with a flair for design? Put your artistic prowess to the test and join our exciting contest, \"Architectural Visions: Redesign Our Identity.\"\r\n\r\nAre you up for the challenge? Unleash your creativity and design a new logo that symbolizes the essence of Architecture, evoking elegance, forward-thinking concepts, and a seamless fusion of form and function.",
                CategoryId = 5,
                PriceToWin = 200,
                IsOnGoing = true
            };
            challenges.Add(challenge);

            challenge = new Challenge()
            {
                Title = "Capturing Nature's Wonders: A Photographic Odyssey",
                ImageUrl = "https://media.cnn.com/api/v1/images/stellar/prod/230706090105-02-monaco-foundation-environmental-photography-awards.jpg?c=original&q=h_618,c_fill",
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
