using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA1
{
    public class Population
    {
        private const string DesiredResult = "1111111111111111111111111111111111111111111111111111111111111111";
        private const int MutationPercentChance = 1;

        public List<Member> Members { get; set; }

        public Population()
        {
            Members = new List<Member>();
        }

        public Population(int populationSize)
        {
            SeedPopulation(populationSize);
        }

        public void SeedPopulation(int populationSize)
        {
            Members = new List<Member>();
            for (var i = 0; i < populationSize; i++)
            {
                this.Members.Add(new Member {Value = Helpers.Generate64BitBinaryString()});
            }
        }

        public Member Evaluate(string desiredResult)
        {
            var desiredResultArray = desiredResult.ToCharArray();

            foreach (var member in Members)
            {
                member.Fitness = 0;
                var valueArray = member.Value.ToCharArray();
                for (var i = 0; i < valueArray.Length; i++)
                {
                    if (valueArray[i] == desiredResultArray[i])
                    {
                        member.Fitness++;
                    }
                }
            }

            return Members.OrderByDescending(x => x.Fitness).FirstOrDefault();
        }

        public Member Breed()
        {
            var fittest = this.Evaluate(DesiredResult);
            var fittestArray = fittest.Value.ToCharArray();

            foreach (var member in this.Members)
            {
                var memberArray = member.Value.ToCharArray();
                for (var i = 0; i < memberArray.Length; i++)
                {
                    // Mutate random gene
                    if (Helpers.GenerateRandomNumber(0, 100) < MutationPercentChance)
                    {
                        memberArray[i] = Helpers.GenerateRandomBit().ToString().ToCharArray()[0];
                    }
                    else
                    {
                        // Breed
                        if (Helpers.GenerateRandomBit() == 1)
                        {
                            memberArray[i] = fittestArray[i];
                        }
                    }
                }
                member.Value = new string(memberArray);
            }
            return fittest;
        }
    }
}