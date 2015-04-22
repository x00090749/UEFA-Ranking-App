package info.androidhive.jsonparsing;

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
        //addListenerOnButton();

        // Starting single contact activity
        // final Intent in = new Intent(getApplicationContext(),
        //       TeamRankingActivity.class);
        //startActivity(in);

        //button = (Button) findViewById(R.id.teamRankingActivityButton);
    }

    public void RoundOneActivity(View view)
    {
        //startActivity(new Intent(MainMenuActivity.this, TeamRankingActivity.class));
        Intent intent = new Intent(this, RoundOneActivity.class);
        startActivity(intent);
    }

    public void RoundTwoActivity(View view)
    {
        //startActivity(new Intent(MainMenuActivity.this, TeamRankingActivity.class));
        Intent intent = new Intent(this, RoundTwoActivity.class);
        startActivity(intent);
    }

    public void MainMenuQualifyingThreeActivity(View view)
    {
        //startActivity(new Intent(MainMenuActivity.this, TeamRankingActivity.class));
        Intent intent = new Intent(this, MainMenuQualifyingThreeActivity.class);
        startActivity(intent);
    }

    public void RoundFourActivity(View view)
    {
        //startActivity(new Intent(MainMenuActivity.this, TeamRankingActivity.class));
        Intent intent = new Intent(this, RoundFourLeagueActivity.class);
        startActivity(intent);
    }

    /*public void MainActivity(View view)
    {
        //startActivity(new Intent(MainMenuActivity.this, TeamRankingActivity.class));
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }*/

}


