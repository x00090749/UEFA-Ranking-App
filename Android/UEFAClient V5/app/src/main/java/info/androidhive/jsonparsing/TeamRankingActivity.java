package info.androidhive.jsonparsing;

import info.androidhive.jsonparsing.R;
import java.util.ArrayList;
import java.util.HashMap;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.app.ListActivity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.TextView;

/**
 * Created by Daniel on 02/04/2015.
 */
public class TeamRankingActivity extends ListActivity
{
    private ProgressDialog pDialog;

    //URL to get Teams
    private static String url = "http://uefaservicev6.azurewebsites.net/api/teamrankings/";

    //JSON Node names
    private static final String TAG_TEAMRANKING = "TeamRanking";
    private static final String TAG_ID = "Id";
    private static final String TAG_TEAMNAME = "TeamName";
    private static final String TAG_COUNTRYCODE = "CountryCode";
    private static final String TAG_RANKING = "Ranking";

    // teamrankings JSONArray
    JSONArray teamRankings = null;

    //Hashmap for ListView
    ArrayList<HashMap<String, String>> teamRankingList;

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        teamRankingList = new ArrayList<HashMap<String, String>>();

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

                // Starting single contact activity
                Intent in = new Intent(getApplicationContext(),
                        SingleContactActivity.class);
                in.putExtra(TAG_TEAMNAME, TeamName); //name
                in.putExtra(TAG_COUNTRYCODE, CountryCode); //cost
                in.putExtra(TAG_RANKING, Ranking); //description
                startActivity(in);

            }
        });

        // Calling async task to get json
        new GetTeamRankings().execute();
    }

    /**
     * Async task class to get json by making HTTP call
     * */
    private class GetTeamRankings extends AsyncTask<Void, Void, Void>
    {

        @Override
        protected void onPreExecute()
        {
            super.onPreExecute();
            // Showing progress dialog
            pDialog = new ProgressDialog(TeamRankingActivity.this);
            pDialog.setMessage("Please wait...");
            pDialog.setCancelable(false);
            pDialog.show();

        }

        @Override
        protected Void doInBackground(Void... arg0) {
            // Creating service handler class instance
            ServiceHandler sh = new ServiceHandler();

            // Making a request to url and getting response
            String jsonStr = sh.makeServiceCall(url, ServiceHandler.GET);

            Log.d("Response: ", "> " + jsonStr);

            if (jsonStr != null) {
                try {
                    JSONArray teamRankings = new JSONArray(jsonStr);
                    //JSONArray countries = new JSONArray(jsonStr);
                    //countries = jsonStr("Country"); //TAG_COUNTRIES

                    // looping through All Countries
                    for (int i = 0; i < teamRankings.length(); i++) {
                        JSONObject c = teamRankings.getJSONObject(i);

                        String Id = c.getString(TAG_ID); //Id
                        String TeamName = c.getString(TAG_TEAMNAME); //"CountryName"
                        String CountryCode = c.getString(TAG_COUNTRYCODE); //"CountryCode
                        String Ranking = c.getString(TAG_RANKING); //"Ranking"


                        // tmp hashmap for single contact
                        HashMap<String, String> teamRanking = new HashMap<String, String>();

                        // adding each child node to HashMap key => value
                        teamRanking.put(TAG_ID, Id);
                        teamRanking.put(TAG_TEAMNAME, TeamName);
                        teamRanking.put(TAG_COUNTRYCODE, CountryCode);
                        teamRanking.put(TAG_RANKING, Ranking);

                        // adding contact to contact list
                        teamRankingList.add(teamRanking); //was country
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
        protected void onPostExecute(Void result) {
            super.onPostExecute(result);
            // Dismiss the progress dialog
            if (pDialog.isShowing())
                pDialog.dismiss();
            /**
             * Updating parsed JSON data into ListView
             * */
            ListAdapter adapter = new SimpleAdapter
                    (
                        TeamRankingActivity.this,
                        teamRankingList,
                        R.layout.list_team,
                        new String[] { TAG_TEAMNAME, TAG_COUNTRYCODE, TAG_RANKING },
                            new int[] { R.id.TeamName,R.id.CountryCode, R.id.Ranking }
                    );

            setListAdapter(adapter);
        }

    }




}
