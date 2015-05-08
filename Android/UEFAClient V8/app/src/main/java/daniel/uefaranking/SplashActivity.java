package daniel.uefaranking;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;

/**
 * Created by Daniel on 21/04/2015.
 */
public class SplashActivity extends Activity
{
    // splash screen timer
    private static int SPLASH_TIME_OUT = 5000;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_splash);

        new Handler().postDelayed(new Runnable()
        {
         /*
			 * Showing splash screen with a timer. This will be useful when you
			 * want to show case your app logo / company
			 */

            @Override
        public void run()
            {
                //Executed after Timer
                Intent i = new Intent(SplashActivity.this, MainMenuActivity.class);
                startActivity(i);

                //close this activity
                finish();
            }

        }, SPLASH_TIME_OUT);
    }


}
