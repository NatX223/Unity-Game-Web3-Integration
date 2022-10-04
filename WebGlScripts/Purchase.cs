using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_WEBGL
public class WebGLSendTransactionExample : MonoBehaviour
{
    async public void OnSendTransaction(float amount)
    {
        // account to send to, smart contract address
        string to = "0x7720Dce30ff35B3560a7b9878Cf6e8d6eAF68645";
        // amount in wei to send, to be passed into the function
        float sendAmount = amount * (10 ** 18);
        string transferAmount = sendAmount.ToString();
        // connects to user's browser wallet (metamask) to send a transaction
        try {
            string response = await Web3GL.SendTransaction(to, value);
            PlayerPrefs.SetFloat("Coins", amount);
            Debug.Log(response);
        } catch (Exception e) {
            Debug.LogException(e, this);
        }
    }
}
#endif