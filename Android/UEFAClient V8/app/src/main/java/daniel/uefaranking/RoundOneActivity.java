package daniel.uefaranking;

import android.app.Activity;
import android.app.ListActivity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;import org.w3c.dom.Text;

import java.util.ArrayList;
import java.util.HashMap;import java.util.List;

/**
 * Created by Daniel on 14/04/2015.
 */
public class RoundOneActivity extends ListActivity
{

    private ProgressDialog pDialog;

    private static String url = "https://uefaservicev9.azurewebsites.net/api/roundonesapi/";

    //Json node keys

    private static final String TAG_ID = "Id";
    private static final String TAG_TEAMNAME = "TeamName";
    private static final String TAG_COUNTRYCODE = "CountryCode";
    private static final String TAG_RANKING = "Ranking";

    String posOne = "";
    String teamArray [] [] = new String[6][4]; //5 3

    JSONArray roundOneArray = null;

    //hashmap for listview
    ArrayList<HashMap<String, String>> roundOneList;

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_qualifying_round);

       roundOneList = new ArrayList<HashMap<String, String>>();

        ListView lv = getListView();

        // Listview on item click listener
        lv.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int positions, long id) {

                // getting values from selected ListItem
                String TeamName = ((TextView) view.findViewById(R.id.TeamName))
                        .getText().toString();
                String CountryCode = ((TextView) view.findViewById(R.id.CountryCode))
                        .getText().toString();
                String Ranking = ((TextView) view.findViewById(R.id.Ranking))
                        .getText().toString();

                // Starting single team activity
                Intent in = new Intent(getApplicationContext(),
                        SingleRoundOneActivity.class);
                in.putExtra(TAG_TEAMNAME, TeamName); //TeamName
                in.putExtra(TAG_COUNTRYCODE, CountryCode); //CountryCode
                in.putExtra(TAG_RANKING, Ranking); //Ranking
                startActivity(in);

            }
        });

        // Calling async task to get json
        new GetRoundOneArray().execute();
    }

    private class GetRoundOneArray extends AsyncTask<Void, Void, Void>
    {

        @Override
        protected void onPreExecute()
        {
            super.onPreExecute();
            // Showing progress dialog
            pDialog = new ProgressDialog(RoundOneActivity.this);
            pDialog.setMessage("Please wait...");
            pDialog.setCancelable(false);
            pDialog.show();

        }

        @Override
        protected Void doInBackground(Void... arg0)
        {
            // Creating service handler class instance
            ServiceHandler sh = new ServiceHandler();

            // Making a request to url and getting response
            String jsonStr = sh.makeServiceCall(url, ServiceHandler.GET);

            Log.d("Response: ", "> " + jsonStr);

            if (jsonStr != null) {
                try {
                    JSONArray roundOneArray = new JSONArray(jsonStr);
                    ArrayList<String> list = new ArrayList<String>();

                    int changer = 0;
                    // looping through All Teams
                    for (int i = 0; i < roundOneArray.length(); i++) {
                        JSONObject c = roundOneArray.getJSONObject(i);

                        String Id = c.getString(TAG_ID); //"Id"
                        String TeamName = c.getString(TAG_TEAMNAME); //"TeamName"
                        String CountryCode = c.getString(TAG_COUNTRYCODE); //"CountryCode
                        String Ranking = c.getString(TAG_RANKING); //"Ranking"

                        posOne = posOne + c.getString(TAG_ID);

                            teamArray[changer][0] = Id;
                            teamArray[changer][1] = TeamName;
                            teamArray[changer][2] = CountryCode;
                            teamArray[changer][3] = Ranking;

                        changer++;

                        // tmp hashmap for single contact
                        HashMap<String, String> roundOne = new HashMap<String, String>();

                        // adding each child node to HashMap key => value
                        roundOne.put(TAG_ID, Id);
                        roundOne.put(TAG_TEAMNAME, TeamName);
                        roundOne.put(TAG_COUNTRYCODE, CountryCode);
                        roundOne.put(TAG_RANKING, Ranking);

                        // adding team to team list
                        roundOneList.add(roundOne);


                    }
                } catch (JSONException e) {
                    e.printStackTrace();
                }
            } else {
                Log.e("ServiceHandler", "Couldn't get any data from the url");
            }

            return null;
        }

        @Override
        protected void onPostExecute(Void result)
        {
            super.onPostExecute(result);
            // Dismiss the progress dialog
            if (pDialog.isShowing())
                pDialog.dismiss();
            /**
             * Updating parsed JSON data into ListView
             * */
           /* String testArray[] = new String[] {TAG_ID, TAG_TEAMNAME, TAG_COUNTRYCODE,
                    TAG_RANKING};*/

            /* ListAdapter adapter = new SimpleAdapter(
                    RoundOneActivity.this, roundOneList,
                    R.layout.list_round_one, new String[]
                     {
                             /*TAG_ID, *//*TAG_TEAMNAME, TAG_COUNTRYCODE, TAG_RANKING
                     }
                     , new int[]{
                           // R.id.Id,
                            R.id.TeamName,
                            R.id.CountryCode,
                            R.id.Ranking
                    });

            setListAdapter(adapter);*/





            // output result
            //TextView TeamID1TextView = (TextView) findViewById(R.id.TeamID1TextView);

            //Team One
            TextView TeamName1TextView = (TextView) findViewById(R.id.TeamName1TextView);
            TextView CountryCode1TextView = (TextView) findViewById(R.id.CountryCode1TextView);
            TextView TeamRanking1TextView = (TextView) findViewById(R.id.TeamRanking1TextView);


            TeamName1TextView.setText(teamArray[0][1]);
            CountryCode1TextView.setText(teamArray[0][2]);
            TeamRanking1TextView.setText(teamArray[0][3]);

            //Team Two
            TextView TeamName2TextView = (TextView) findViewById(R.id.TeamName2TextView);
            TextView CountryCode2TextView = (TextView) findViewById(R.id.CountryCode2TextView);
            TextView TeamRanking2TextView = (TextView) findViewById(R.id.TeamRanking2TextView);


            TeamName2TextView.setText(teamArray[1][1]);
            CountryCode2TextView.setText(teamArray[1][2]);
            TeamRanking2TextView.setText(teamArray[1][3]);

            //Team Three
            TextView TeamName3TextView = (TextView) findViewById(R.id.TeamName3TextView);
            TextView CountryCode3TextView = (TextView) findViewById(R.id.CountryCode3TextView);
            TextView TeamRanking3TextView = (TextView) findViewById(R.id.TeamRanking3TextView);


            TeamName3TextView.setText(teamArray[2][1]);
            CountryCode3TextView.setText(teamArray[2][2]);
            TeamRanking3TextView.setText(teamArray[2][3]);

            //Team Four
            TextView TeamName4TextView = (TextView) findViewById(R.id.TeamName4TextView);
            TextView CountryCode4TextView = (TextView) findViewById(R.id.CountryCode4TextView);
            TextView TeamRanking4TextView = (TextView) findViewById(R.id.TeamRanking4TextView);


            TeamName4TextView.setText(teamArray[3][1]);
            CountryCode4TextView.setText(teamArray[3][2]);
            TeamRanking4TextView.setText(teamArray[3][3]);

            //Team Five
            TextView TeamName5TextView = (TextView) findViewById(R.id.TeamName5TextView);
            TextView CountryCode5TextView = (TextView) findViewById(R.id.CountryCode5TextView);
            TextView TeamRanking5TextView = (TextView) findViewById(R.id.TeamRanking5TextView);


            TeamName5TextView.setText(teamArray[4][1]);
            CountryCode5TextView.setText(teamArray[4][2]);
            TeamRanking5TextView.setText(teamArray[4][3]);

            //Team Six
            TextView TeamName6TextView = (TextView) findViewById(R.id.TeamName6TextView);
            TextView CountryCode6TextView = (TextView) findViewById(R.id.CountryCode6TextView);
            TextView TeamRanking6TextView = (TextView) findViewById(R.id.TeamRanking6TextView);


            TeamName6TextView.setText(teamArray[5][1]);
            CountryCode6TextView.setText(teamArray[5][2]);
            TeamRanking6TextView.setText(teamArray[5][3]);

        }

    }









}
