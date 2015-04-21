package info.androidhive.jsonparsing;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

/**
 * Created by Daniel on 21/04/2015.
 */
public class MainMenuQualifyingThreeActivity extends Activity
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

    public void RoundThreeChampionsActivity(View view)
    {
        //startActivity(new Intent(MainMenuActivity.this, TeamRankingActivity.class));
        Intent intent = new Intent(this, RoundOneActivity.class);
        startActivity(intent);
    }

    public void RoundThreeLeagueActivity(View view)
    {
        //startActivity(new Intent(MainMenuActivity.this, TeamRankingActivity.class));
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }

}






