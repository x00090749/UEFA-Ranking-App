package info.androidhive.jsonparsing;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.widget.Button;
import android.view.View.OnClickListener;
import android.content.Intent;

/**
 * Created by Daniel on 18/04/2015.
 */
public class MainMenuActivity extends Activity
{
    Button button;

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_menu);
        //addListenerOnButton();

        // Starting single contact activity
        // final Intent in = new Intent(getApplicationContext(),
        //       TeamRankingActivity.class);
        //startActivity(in);

        //button = (Button) findViewById(R.id.teamRankingActivityButton);
    }
    public void MainMenuQualifyingActivity(View view)
    {
        startActivity(new Intent(MainMenuActivity.this, MainMenuQualifyingActivity.class));
       // Intent qualIntent = new Intent(MainMenuActivity.this, MainMenuQualifyingActivity.class);
       // startActivity(intent);
    }

    public void TeamRankingActivity(View view)
    {
        startActivity(new Intent(this, TeamRankingActivity.class));
        //Intent roundIntent = new Intent(MainMenuActivity.this, RoundOneActivity.class);
        //startActivity(roundIntent);
    }

    public void MainActivity(View view) {
        startActivity(new Intent(MainMenuActivity.this, MainActivity.class));
        //Intent mainIntent = new Intent(MainMenuActivity.this, MainActivity.class);
        //startActivity(mainIntent);
    }

    public void HelpActivity(View view) {
        startActivity(new Intent(MainMenuActivity.this, HelpActivity.class));
        //Intent mainIntent = new Intent(MainMenuActivity.this, MainActivity.class);
        //startActivity(mainIntent);
    }

    public void AboutActivity(View view) {
        startActivity(new Intent(MainMenuActivity.this, AboutActivity.class));
        //Intent mainIntent = new Intent(MainMenuActivity.this, MainActivity.class);
        //startActivity(mainIntent);
    }

}


