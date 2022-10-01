using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Web3PrivateKeyMintingNFT : MonoBehaviour
{
        // private key of account
        // replace own private key
        public string privateKey = "0x78dae1a22c7507a4ed30c06172e7614eb168d3546c13856340771e63ad3c0081";
        // set chain: CoinEx
        public string chain = "CoinEx";
        // set network mainnet, testnet
        public string network = "testnet";
        // abi to interact with contract
        // replace with custom abi
        public string abi = "[ { \"inputs\": [ { \"internalType\": \"string\", \"name\": \"name_\", \"type\": \"string\" }, { \"internalType\": \"string\", \"name\": \"symbol_\", \"type\": \"string\" } ], \"stateMutability\": \"nonpayable\", \"type\": \"constructor\" }, { \"anonymous\": false, \"inputs\": [ { \"indexed\": true, \"internalType\": \"address\", \"name\": \"owner\", \"type\": \"address\" }, { \"indexed\": true, \"internalType\": \"address\", \"name\": \"spender\", \"type\": \"address\" }, { \"indexed\": false, \"internalType\": \"uint256\", \"name\": \"value\", \"type\": \"uint256\" } ], \"name\": \"Approval\", \"type\": \"event\" }, { \"anonymous\": false, \"inputs\": [ { \"indexed\": true, \"internalType\": \"address\", \"name\": \"from\", \"type\": \"address\" }, { \"indexed\": true, \"internalType\": \"address\", \"name\": \"to\", \"type\": \"address\" }, { \"indexed\": false, \"internalType\": \"uint256\", \"name\": \"value\", \"type\": \"uint256\" } ], \"name\": \"Transfer\", \"type\": \"event\" }, { \"inputs\": [ { \"internalType\": \"address\", \"name\": \"owner\", \"type\": \"address\" }, { \"internalType\": \"address\", \"name\": \"spender\", \"type\": \"address\" } ], \"name\": \"allowance\", \"outputs\": [ { \"internalType\": \"uint256\", \"name\": \"\", \"type\": \"uint256\" } ], \"stateMutability\": \"view\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"address\", \"name\": \"spender\", \"type\": \"address\" }, { \"internalType\": \"uint256\", \"name\": \"amount\", \"type\": \"uint256\" } ], \"name\": \"approve\", \"outputs\": [ { \"internalType\": \"bool\", \"name\": \"\", \"type\": \"bool\" } ], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"address\", \"name\": \"account\", \"type\": \"address\" } ], \"name\": \"balanceOf\", \"outputs\": [ { \"internalType\": \"uint256\", \"name\": \"\", \"type\": \"uint256\" } ], \"stateMutability\": \"view\", \"type\": \"function\" }, { \"inputs\": [], \"name\": \"decimals\", \"outputs\": [ { \"internalType\": \"uint8\", \"name\": \"\", \"type\": \"uint8\" } ], \"stateMutability\": \"view\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"address\", \"name\": \"spender\", \"type\": \"address\" }, { \"internalType\": \"uint256\", \"name\": \"subtractedValue\", \"type\": \"uint256\" } ], \"name\": \"decreaseAllowance\", \"outputs\": [ { \"internalType\": \"bool\", \"name\": \"\", \"type\": \"bool\" } ], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"address\", \"name\": \"spender\", \"type\": \"address\" }, { \"internalType\": \"uint256\", \"name\": \"addedValue\", \"type\": \"uint256\" } ], \"name\": \"increaseAllowance\", \"outputs\": [ { \"internalType\": \"bool\", \"name\": \"\", \"type\": \"bool\" } ], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"inputs\": [], \"name\": \"name\", \"outputs\": [ { \"internalType\": \"string\", \"name\": \"\", \"type\": \"string\" } ], \"stateMutability\": \"view\", \"type\": \"function\" }, { \"inputs\": [], \"name\": \"symbol\", \"outputs\": [ { \"internalType\": \"string\", \"name\": \"\", \"type\": \"string\" } ], \"stateMutability\": \"view\", \"type\": \"function\" }, { \"inputs\": [], \"name\": \"totalSupply\", \"outputs\": [ { \"internalType\": \"uint256\", \"name\": \"\", \"type\": \"uint256\" } ], \"stateMutability\": \"view\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"address\", \"name\": \"recipient\", \"type\": \"address\" }, { \"internalType\": \"uint256\", \"name\": \"amount\", \"type\": \"uint256\" } ], \"name\": \"transfer\", \"outputs\": [ { \"internalType\": \"bool\", \"name\": \"\", \"type\": \"bool\" } ], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"address\", \"name\": \"sender\", \"type\": \"address\" }, { \"internalType\": \"address\", \"name\": \"recipient\", \"type\": \"address\" }, { \"internalType\": \"uint256\", \"name\": \"amount\", \"type\": \"uint256\" } ], \"name\": \"transferFrom\", \"outputs\": [ { \"internalType\": \"bool\", \"name\": \"\", \"type\": \"bool\" } ], \"stateMutability\": \"nonpayable\", \"type\": \"function\" } ]";
        // contract Address
        public string contract = "";
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

    async public void mintNormalSkin1 ()
    {
        string id = "1";
        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, playerAccount, id);
        if(balanceOf >= 1) {
            print("You can not own more than one of the token");
        }
        else {
        if(playerCoins <= 5.0) {
            print("You do not have enough Coins to perform the operation")
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
            print("You do not have enough Coins to perform the operation")
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
            print("You do not have enough Coins to perform the operation")
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
}
