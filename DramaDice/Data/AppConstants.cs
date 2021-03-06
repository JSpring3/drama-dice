namespace DramaDice.Data;

public static class RouteNames
{
    public const string HOME = "/";
    public const string SETTINGS = "/settings";
    public const string CHARACTER = "/character";
    public const string ROLL_RESULTS = "/roll-results";
}

public static class WebHookInfoToast
{
    public const string MESSAGE = "You must save a Discord or Guilded.GG WebHook Url to continue! Get it from your Game Master.";
    public const string TITLE = "WebHook Setup";
}
public static class WebHookSaveToast
{
    public const string MESSAGE = "WebHook Saved!";
    public const string TITLE = "Success";

}

public static class WebHookErrorToast
{
    public const string MESSAGE = "WebHooks start with https://discord.com/api/webhooks/  or https://media.guilded.gg/webhooks  ...Please check the link again";
    public const string TITLE = "Bad WebHook";
}

public static class SendToDiscordErrorToast
{
    public const string MESSAGE = "Error Sending to Chat Server. Check your settings and try again.";
    public const string TITLE = "Failure";
}

public static class SendToDiscordSuccessToast
{
    public const string MESSAGE = "Chat Message Sent";
    public const string TITLE = "Success!";
}

public static class LocalStorage
{
    public const string WEBHOOK = "webHook";
    public const string CHARACTER_NAME = "characterName";
    public const string CHARACTER_TYPE = "characterType";
    public const string MSG_TYPE = "msgType";
    public const string DICE_POOL = "dicePool";
    public const string SUCCESS_TARGET = "successTarget";
    public const string USE_PLUS_ONE = "usePlusOne";
    public const string USE_LEGENDARY = "useLegendary";
    public const string USE_EXPLODE = "useExplode";
    public const string HERO_POINTS = "heroPoints";
    public const string WEALTH = "wealth";
    public const string ROLL_HISTORY = "rollHistory";
}

public static class Validation
{
    public const string URL_CHECK_VALUE_DISCORD = "https://discord.com/api/webhooks";
    public const string URL_CHECK_VALUE_GUILDED = "https://media.guilded.gg/webhooks";
}