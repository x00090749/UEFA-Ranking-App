package daniel.uefaranking;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class MainMenuQualifyingThreeActivity extends Activity
{
    Button button;

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_qualifying_menu_three);
    }

    //Third Round Champions Intent
    public void RoundThreeChampionsActivity(View view)
    {
        Intent intent = new Intent(this, RoundThreeChampionsActivity.class);
        startActivity(intent);
    }

    //Third Round League Route Intent
    public void RoundThreeLeagueActivity(View view)
    {
        Intent intent = new Intent(this, RoundThreeLeagueActivity.class);
        startActivity(intent);
    }

}






