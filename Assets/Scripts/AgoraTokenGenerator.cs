using System;
using System.Collections;
using System.Collections.Generic;
using AgoraIO.Media;
using UnityEngine;

public class AgoraTokenGenerator

{
    private string appId = "<Your app Id>";
    private string appCertificate = "<Your app Certificate>";
    private string channelName = "<Your channel name>";
    private string uid = "0";
    private string userAccount = "User account";
    private int expirationTimeInSeconds = 3600; // The time after which the token expires

    public AgoraTokenGenerator(string appId, string appCertificate, string channelName, string uid, string userAccount, int expirationTimeInSeconds)
    {
        this.appId = appId;
        this.appCertificate = appCertificate;
        this.channelName = channelName;
        this.uid = uid;
        this.userAccount = userAccount;
        this.expirationTimeInSeconds = expirationTimeInSeconds;
    }

    public string GenerateDynamicKey()
    {
        AccessToken token = new AccessToken(appId, appCertificate, channelName, uid);
        string token2 = SignalingToken.getToken(appId, appCertificate, userAccount, expirationTimeInSeconds);
        // Specify a privilege level and expire time for the token
        token.addPrivilege(Privileges.kPublishVideoStream, Convert.ToUInt32(expirationTimeInSeconds));
        string result = token.build();
        Debug.Log("Token based on uid :" + result);

        return result;
    }
    
    
}
