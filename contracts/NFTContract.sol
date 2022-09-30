// SPDX-License-Identifier: SEE LICENSE IN LICENSE
pragma solidity ^0.8.0;

// importing the ERC1155 standard contract
import "@openzeppelin/contracts/token/ERC1155.sol";

contract NFTStore is ERC1155 {
    // TODO
    // Construct Token JSON files and deploy to IPFS
    // then paste in URI
    address public deployer;
    constructor() ERC1155("https://nftstorage.link/ipfs/bafybeidxz5vjfkgmtoinmrpnsojznjb2mvcdkbceytdkff2xvwcjcpfape/{id}.json") {
        msg.sender = deployer;
    }

    // function to mint the token to the caller
    function mint(address to, uint id) public {
        _mint(to, id, 1, 0);
    }
}