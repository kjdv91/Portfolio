using Portfolio.Models;

namespace Portfolio.Services
{
    public class RepositoryProject: IRepositoryProject
    {
        public  List<ProjectDto> GetProject()
        {
            return new List<ProjectDto>()
            { new ProjectDto
            {
                Title = "Nft Collection",
                Description = "Dapp mint nft usando solidity, react, ipfs",
                Link = "https://squarenft.netlify.app",
                ImageUrl = "/img/NftCollection.jpg"

            },
            new ProjectDto
            {
                Title = "Game Nft",
                Description = "Game nft creado con solidity y react",
                Link = "https://gamenfts.netlify.app/",
                ImageUrl= "/img/GameNft.jpg"

            },
            new ProjectDto
            {
                Title = "Game Nft",
                Description = "Game nft creado con solidity y react",
                Link = "https://gamenfts.netlify.app/",
                ImageUrl = "/img/GameNft.jpg"

            }


             };

        }

       
    }
}
