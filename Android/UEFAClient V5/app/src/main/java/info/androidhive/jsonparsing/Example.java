package info.androidhive.jsonparsing;

import android.app.Activity;import android.os.Bundle;import android.widget.LinearLayout;import android.widget.TextView; /**
 * Created by Daniel on 22/04/2015.
 */
public class Example extends Activity {
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);

        LinearLayout myLayout = (LinearLayout) findViewById(R.id.my_layout);
        LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams( LinearLayout.LayoutParams.WRAP_CONTENT,    LinearLayout.LayoutParams.WRAP_CONTENT);
        TextView[] pairs=new TextView[4];
        for(int l=0; l<4; l++)
        {
            pairs[l] = new TextView(this);
            pairs[l].setTextSize(15);
            pairs[l].setLayoutParams(lp);
            pairs[l].setId(l);
            pairs[l].setText((l + 1) + ": something");
            myLayout.addView(pairs[l]);
        }

    }
}