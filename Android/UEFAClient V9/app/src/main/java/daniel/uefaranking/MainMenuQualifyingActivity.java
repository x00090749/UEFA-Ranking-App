package daniel.uefaranking;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

/**
 * Created by Daniel on 19/04/2015.
 */
public class MainMenuQualifyingActivity extends Activity
{
    Button button;

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_qualifying_menu);
    }

    //Round One Intent
    public void RoundOneActivity(View view)
    {
        Intent intent = new Intent(this, RoundOneActivity.class);
        startActivity(intent);
    }

    //Round Two Intent
    public void RoundTwoActivity(View view)
    {
        Intent intent = new Intent(this, RoundTwoActivity.class);
        startActivity(intent);
    }

    //Round Three Menu Intent
    public void MainMenuQualifyingThreeActivity(View view)
    {
        Intent intent = new Intent(this, MainMenuQualifyingThreeActivity.class);
        startActivity(intent);
    }

    //Round Four Intent
    public void RoundFourActivity(View view)
    {
        Intent intent = new Intent(this, RoundFourLeagueActivity.class);
        startActivity(intent);
    }

    //Group Stage Intent
    public void GroupStageActivity(View view)
    {
        Intent intent = new Intent(this, GroupStageActivity.class);
        startActivity(intent);
    }
}


