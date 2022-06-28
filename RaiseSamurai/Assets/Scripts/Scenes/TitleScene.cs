using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void SceneSetting()
    {
        SceneType = Defines.Scenes.Title;
        SceneName = "Title";
        Managers.Sound.Play("BGM/TitleBgm", Defines.Sounds.Bgm);
    }
    protected override void ObjectInit()
    {
        Managers.Actor.Spawn(Defines.Actors.Player, "Player/Player");
        Managers.UI.ShowSceneUI<UI_BackGround>("UI_BackGround");
        Managers.UI.ShowSceneUI<UI_TitleInterface>("UI_TitleInterface");
    }

    public override void Clear()
    {

    }
}
