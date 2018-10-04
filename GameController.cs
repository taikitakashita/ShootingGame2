using System;

public class Class1
{
	public Class1()
	{
        // Update is called once per frame
        void loadScene()
        {
            if (Input.GetMouseButtonDown(1))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}
