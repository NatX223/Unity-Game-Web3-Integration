using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Web3PrivateKeyMintingNFT : MonoBehaviour
{
        // private key of account
        // replace own private key
        public string privateKey = "05a78a752e876b28304ed67c6c0cb05545693c99df446e8f8c27734209240e8c";
        // set chain: CoinEx
        public string chain = "CoinEx";
        // set network mainnet, testnet
        public string network = "testnet";
        // abi to interact with contract
        // replace with custom abi
        public string abi ="[ { \"inputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"constructor\" }, { \"anonymous\": false, \"inputs\": [ { \"indexed\": true, \"internalType\": \"address\", \"name\": \"account\", \"type\": \"address\" }, { \"indexed\": true, \"internalType\": \"address\", \"name\": \"operator\", \"type\": \"address\" }, { \"indexed\": false, \"internalType\": \"bool\", \"name\": \"approved\", \"type\": \"bool\" } ], \"name\": \"ApprovalForAll\", \"type\": \"event\" }, { \"anonymous\": false, \"inputs\": [ { \"indexed\": true, \"internalType\": \"address\", \"name\": \"operator\", \"type\": \"address\" }, { \"indexed\": true, \"internalType\": \"address\", \"name\": \"from\", \"type\": \"address\" }, { \"indexed\": true, \"internalType\": \"address\", \"name\": \"to\", \"type\": \"address\" }, { \"indexed\": false, \"internalType\": \"uint256[]\", \"name\": \"ids\", \"type\": \"uint256[]\" }, { \"indexed\": false, \"internalType\": \"uint256[]\", \"name\": \"values\", \"type\": \"uint256[]\" } ], \"name\": \"TransferBatch\", \"type\": \"event\" }, { \"anonymous\": false, \"inputs\": [ { \"indexed\": true, \"internalType\": \"address\", \"name\": \"operator\", \"type\": \"address\" }, { \"indexed\": true, \"internalType\": \"address\", \"name\": \"from\", \"type\": \"address\" }, { \"indexed\": true, \"internalType\": \"address\", \"name\": \"to\", \"type\": \"address\" }, { \"indexed\": false, \"internalType\": \"uint256\", \"name\": \"id\", \"type\": \"uint256\" }, { \"indexed\": false, \"internalType\": \"uint256\", \"name\": \"value\", \"type\": \"uint256\" } ], \"name\": \"TransferSingle\", \"type\": \"event\" }, { \"anonymous\": false, \"inputs\": [ { \"indexed\": false, \"internalType\": \"string\", \"name\": \"value\", \"type\": \"string\" }, { \"indexed\": true, \"internalType\": \"uint256\", \"name\": \"id\", \"type\": \"uint256\" } ], \"name\": \"URI\", \"type\": \"event\" }, { \"inputs\": [ { \"internalType\": \"address\", \"name\": \"account\", \"type\": \"address\" }, { \"internalType\": \"uint256\", \"name\": \"id\", \"type\": \"uint256\" } ], \"name\": \"balanceOf\", \"outputs\": [ { \"internalType\": \"uint256\", \"name\": \"\", \"type\": \"uint256\" } ], \"stateMutability\": \"view\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"address[]\", \"name\": \"accounts\", \"type\": \"address[]\" }, { \"internalType\": \"uint256[]\", \"name\": \"ids\", \"type\": \"uint256[]\" } ], \"name\": \"balanceOfBatch\", \"outputs\": [ { \"internalType\": \"uint256[]\", \"name\": \"\", \"type\": \"uint256[]\" } ], \"stateMutability\": \"view\", \"type\": \"function\" }, { \"inputs\": [], \"name\": \"deployer\", \"outputs\": [ { \"internalType\": \"address\", \"name\": \"\", \"type\": \"address\" } ], \"stateMutability\": \"view\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"address\", \"name\": \"account\", \"type\": \"address\" }, { \"internalType\": \"address\", \"name\": \"operator\", \"type\": \"address\" } ], \"name\": \"isApprovedForAll\", \"outputs\": [ { \"internalType\": \"bool\", \"name\": \"\", \"type\": \"bool\" } ], \"stateMutability\": \"view\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"address\", \"name\": \"to\", \"type\": \"address\" }, { \"internalType\": \"uint256\", \"name\": \"id\", \"type\": \"uint256\" } ], \"name\": \"mint\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"address\", \"name\": \"from\", \"type\": \"address\" }, { \"internalType\": \"address\", \"name\": \"to\", \"type\": \"address\" }, { \"internalType\": \"uint256[]\", \"name\": \"ids\", \"type\": \"uint256[]\" }, { \"internalType\": \"uint256[]\", \"name\": \"amounts\", \"type\": \"uint256[]\" }, { \"internalType\": \"bytes\", \"name\": \"data\", \"type\": \"bytes\" } ], \"name\": \"safeBatchTransferFrom\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"address\", \"name\": \"from\", \"type\": \"address\" }, { \"internalType\": \"address\", \"name\": \"to\", \"type\": \"address\" }, { \"internalType\": \"uint256\", \"name\": \"id\", \"type\": \"uint256\" }, { \"internalType\": \"uint256\", \"name\": \"amount\", \"type\": \"uint256\" }, { \"internalType\": \"bytes\", \"name\": \"data\", \"type\": \"bytes\" } ], \"name\": \"safeTransferFrom\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"address\", \"name\": \"operator\", \"type\": \"address\" }, { \"internalType\": \"bool\", \"name\": \"approved\", \"type\": \"bool\" } ], \"name\": \"setApprovalForAll\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"bytes4\", \"name\": \"interfaceId\", \"type\": \"bytes4\" } ], \"name\": \"supportsInterface\", \"outputs\": [ { \"internalType\": \"bool\", \"name\": \"\", \"type\": \"bool\" } ], \"stateMutability\": \"view\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"uint256\", \"name\": \"\", \"type\": \"uint256\" } ], \"name\": \"uri\", \"outputs\": [ { \"internalType\": \"string\", \"name\": \"\", \"type\": \"string\" } ], \"stateMutability\": \"view\", \"type\": \"function\" } ]";
        // please format this C# string with /"string/"
        // contract Address
        public string contract = "0x7720Dce30ff35B3560a7b9878Cf6e8d6eAF68645";
        // account of sender
        public string account = Web3PrivateKey.Address(privateKey);
        // value in wei
        public string value = "0";
        // CoinEx rpc url
        public string rpc = "https://testnet-rpc.coinex.net";
        // getting the Players Account address
        public string playerAccount = PlayerPrefs.GetString("Account");
        // getting the Players coins balance
        public float playerCoins = PlayerPrefs.GetFloat("Coins");
        // getting the Players status if boss has been defeated
        public float playerBoss = PlayerPrefs.GetInt("Boss");

    async public void mintNormalSkin1 ()
    {
        string id = "1";
        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, playerAccount, id);
        if(balanceOf >= 1) {
            print("You can not own more than one of the token");
        }
        else {
        if(playerCoins <= 5.0) {
            print("You do not have enough Coins to perform the operation");
        }
        else {
                string[] obj = { playerAccount, id };
                string args = JsonConvert.SerializeObject(obj);
                string transaction = await EVM.CreateTransaction(chain, network, account, to, value, data, gasPrice, gasLimit, rpc);
                string signature = Web3PrivateKey.SignTransaction(privateKey, transaction, chainId);
                string response = await EVM.BroadcastTransaction(chain, network, account, to, value, data, signature, gasPrice, gasLimit, rpc);
                string txStatus = await EVM.TxStatus(chain, network, transaction);
                if(txStatus == "success") {
                    int newCoins = playerCoins - 5;
                    PlayerPrefs.SetInt("Coins", newCoins);
                    print("You have successfully minted the skin");
                }
                else {
                    print("Something went wrong");
                }
            }
        }
    }

        async public void mintNormalSkin2 ()
    {
        string id = "2";
        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, playerAccount, id);
        if(balanceOf >= 1) {
            print("You can not own more than one of the token");
        }
        else {
        if(playerCoins <= 5.0) {
            print("You do not have enough Coins to perform the operation");
        }
        else {
                string[] obj = { playerAccount, id };
                string args = JsonConvert.SerializeObject(obj);
                string transaction = await EVM.CreateTransaction(chain, network, account, to, value, data, gasPrice, gasLimit, rpc);
                string signature = Web3PrivateKey.SignTransaction(privateKey, transaction, chainId);
                string response = await EVM.BroadcastTransaction(chain, network, account, to, value, data, signature, gasPrice, gasLimit, rpc);
                string txStatus = await EVM.TxStatus(chain, network, transaction);
                if(txStatus == "success") {
                    int newCoins = playerCoins - 5;
                    PlayerPrefs.SetInt("Coins", newCoins);
                    print("You have successfully minted the skin");
                }
                else {
                    print("Something went wrong");
                }
            }
        }
    }

        async public void mintNormalSkin3 ()
    {
        string id = "3";
        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, playerAccount, id);
        if(balanceOf >= 1) {
            print("You can not own more than one of the token");
        }
        else {
        if(playerCoins <= 5.0) {
            print("You do not have enough Coins to perform the operation");
        }
        else {
                string[] obj = { playerAccount, id };
                string args = JsonConvert.SerializeObject(obj);
                string transaction = await EVM.CreateTransaction(chain, network, account, to, value, data, gasPrice, gasLimit, rpc);
                string signature = Web3PrivateKey.SignTransaction(privateKey, transaction, chainId);
                string response = await EVM.BroadcastTransaction(chain, network, account, to, value, data, signature, gasPrice, gasLimit, rpc);
                string txStatus = await EVM.TxStatus(chain, network, transaction);
                if(txStatus == "success") {
                    int newCoins = playerCoins - 5;
                    PlayerPrefs.SetInt("Coins", newCoins);
                    print("You have successfully minted the skin");
                }
                else {
                    print("Something went wrong");
                }
            }
        }
    }

        async public void mintRareSkin1 ()
    {
        int Boss = PlayerPrefs;
        string id = "11";
        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, playerAccount, id);
        if(balanceOf >= 1) {
            print("You can not own more than one of the token");
        }
        else {
        if(playerBoss != 1) {
            print("You have defeated the boss, so you can not this skin");
        }
        else {
                string[] obj = { playerAccount, id };
                string args = JsonConvert.SerializeObject(obj);
                string transaction = await EVM.CreateTransaction(chain, network, account, to, value, data, gasPrice, gasLimit, rpc);
                string signature = Web3PrivateKey.SignTransaction(privateKey, transaction, chainId);
                string response = await EVM.BroadcastTransaction(chain, network, account, to, value, data, signature, gasPrice, gasLimit, rpc);
                string txStatus = await EVM.TxStatus(chain, network, transaction);
                if(txStatus == "success") {
                    print("You have successfully minted the skin");
                }
                else {
                    print("Something went wrong");
                }
            }
        }
    }

        async public void mintRareSkin2 ()
    {
        int Boss = PlayerPrefs;
        string id = "12";
        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, playerAccount, id);
        if(balanceOf >= 1) {
            print("You can not own more than one of the token");
        }
        else {
        if(playerBoss != 1) {
            print("You have defeated the boss, so you can not this skin");
        }
        else {
                string[] obj = { playerAccount, id };
                string args = JsonConvert.SerializeObject(obj);
                string transaction = await EVM.CreateTransaction(chain, network, account, to, value, data, gasPrice, gasLimit, rpc);
                string signature = Web3PrivateKey.SignTransaction(privateKey, transaction, chainId);
                string response = await EVM.BroadcastTransaction(chain, network, account, to, value, data, signature, gasPrice, gasLimit, rpc);
                string txStatus = await EVM.TxStatus(chain, network, transaction);
                if(txStatus == "success") {
                    print("You have successfully minted the skin");
                }
                else {
                    print("Something went wrong");
                }
            }
        }
    }

        async public void mintRareSkin3 ()
    {
        int Boss = PlayerPrefs;
        string id = "13";
        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, playerAccount, id);
        if(balanceOf >= 1) {
            print("You can not own more than one of the token");
        }
        else {
        if(playerBoss != 1) {
            print("You have defeated the boss, so you can not this skin");
        }
        else {
                string[] obj = { playerAccount, id };
                string args = JsonConvert.SerializeObject(obj);
                string transaction = await EVM.CreateTransaction(chain, network, account, to, value, data, gasPrice, gasLimit, rpc);
                string signature = Web3PrivateKey.SignTransaction(privateKey, transaction, chainId);
                string response = await EVM.BroadcastTransaction(chain, network, account, to, value, data, signature, gasPrice, gasLimit, rpc);
                string txStatus = await EVM.TxStatus(chain, network, transaction);
                if(txStatus == "success") {
                    print("You have successfully minted the skin");
                }
                else {
                    print("Something went wrong");
                }
            }
        }
    }

}
