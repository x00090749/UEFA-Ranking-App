package info.androidhive.jsonparsing;

import android.app.ListActivity;import android.app.ProgressDialog;import android.content.Intent;import android.os.AsyncTask;import android.os.Bundle;import android.util.Log;import android.view.View;import android.widget.AdapterView;import android.widget.ListAdapter;import android.widget.ListView;import android.widget.SimpleAdapter;import android.widget.TextView;import org.json.JSONArray;import org.json.JSONException;import org.json.JSONObject;import java.util.ArrayList;import java.util.HashMap; /**
 * Created by Daniel on 22/04/2015.
 */
public class RoundFourLeagueActivity extends ListActivity
{
    private ProgressDialog pDialog;

    private static String url = "https://uefaservicev9.azurewebsites.net/api/roundfourleagueroutesapi/";

    //Json node keys

    private static final String TAG_ID = "Id";
    private static final String TAG_TEAMNAME = "TeamName";
    private static final String TAG_COUNTRYCODE = "CountryCode";
    private static final String TAG_RANKING = "Ranking";

    JSONArray roundThreeChampionsArray = null;

    //hashmap for listview
    ArrayList<HashMap<String, String>> roundFourLeagueList;

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        //setContentView(R.layout.activity_round_one);
        setContentView(R.layout.activity_round_one);

        roundFourLeagueList = new ArrayList<HashMap<String, String>>();

        ListView lv = getListView();

        // Listview on item click listener
        lv.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int positions, long id) {

                // getting values from selected ListItem
                String Id = ((TextView) view.findViewById(R.id.Id))
                        .getText().toString();
                String TeamName = ((TextView) view.findViewById(R.id.TeamName))
                        .getText().toString();
                String CountryCode = ((TextView) view.findViewById(R.id.CountryCode))
                        .getText().toString();
                String Ranking = ((TextView) view.findViewById(R.id.Ranking))
                        .getText().toString();

                // Starting single contact activity
                Intent in = new Intent(getApplicationContext(),
                        SingleRoundOneActivity.class);
                in.putExtra(TAG_ID, Id); //Id
                in.putExtra(TAG_TEAMNAME, TeamName); //name
                in.putExtra(TAG_COUNTRYCODE, CountryCode); //cost
                in.putExtra(TAG_RANKING, Ranking); //description
                startActivity(in);

            }
        });

        // Calling async task to get json
        new GetRoundFourLeagueArray().execute();
    }

    private class GetRoundFourLeagueArray extends AsyncTask<Void, Void, Void>
    {

        @Override
        protected void onPreExecute()
        {
            super.onPreExecute();
            // Showing progress dialog
            pDialog = new ProgressDialog(RoundFourLeagueActivity.this);
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
                    JSONArray roundFourLeagueArray = new JSONArray(jsonStr);
                    //JSONArray roundOne = new JSONArray(jsonStr);
                    //roundOne = jsonStr("Country"); //TAG_COUNTRIES

                    // looping through All Countries
                    for (int i = 0; i < roundFourLeagueArray.length(); i++) {
                        JSONObject c = roundFourLeagueArray.getJSONObject(i);

                        String Id = "Position: " + c.getString(TAG_ID); //Id
                        String TeamName = "Team Name: " + c.getString(TAG_TEAMNAME); //"CountryName"
                        String CountryCode = c.getString(TAG_COUNTRYCODE); //"CountryCode
                        String Ranking = "Coefficient: " + c.getString(TAG_RANKING); //"Position"

                        // tmp hashmap for single contact
                        HashMap<String, String> roundFourLeague = new HashMap<String, String>();

                        // adding each child node to HashMap key => value
                        roundFourLeague.put(TAG_ID, Id);
                        roundFourLeague.put(TAG_TEAMNAME, TeamName);
                        roundFourLeague.put(TAG_COUNTRYCODE, CountryCode);
                        roundFourLeague.put(TAG_RANKING, Ranking);

                        // adding contact to contact list
                        roundFourLeagueList.add(roundFourLeague);


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

            ListAdapter adapter = new SimpleAdapter(
                    RoundFourLeagueActivity.this, roundFourLeagueList,
                    R.layout.list_round_one, new String[]
                    {
                             TAG_ID, TAG_TEAMNAME, TAG_COUNTRYCODE, TAG_RANKING
                    }
                    , new int[]{
                    R.id.Id,
                    R.id.TeamName,
                    R.id.CountryCode,
                    R.id.Ranking
            });

            setListAdapter(adapter);

            // output result
            /*TextView testTextView = (TextView) findViewById(R.id.testTextView);
            testTextView.setText("Test Team: " + test + "");*/
        }

    }

}