// SPDX-License-Identifier: SEE LICENSE IN LICENSE
pragma solidity ^0.8.0;

// importing the ERC1155 standard contract
import "@openzeppelin/contracts/token/ERC1155/ERC1155.sol";

contract NFTStore is ERC1155 {
    // TODO
    // Construct Token JSON files and deploy to IPFS
    // then paste in URI
    address public deployer;
    constructor() ERC1155("ipfs://bafybeidxz5vjfkgmtoinmrpnsojznjb2mvcdkbceytdkff2xvwcjcpfape/{id}.json") {
        deployer = msg.sender;
    }

    // function to mint the token to the caller
    function mint(address to, uint id) public {
        require(msg.sender == deployer, "only deployer can mint NFT skin");
        string memory _i = "0";
        bytes memory i = abi.encodePacked(_i);
        _mint(to, id, 1, i);
    }
}