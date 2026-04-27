# Google Business Profile Hunter 🎯

A completed Full-Stack application designed to automate lead generation by extracting data from the Google Places ecosystem. This tool allows users to scrape, visualize, and filter business data to identify high-value targets across any geography.

## 📝 Project Overview
This project solves the manual labor of lead prospecting. By interfacing with the **Google Places API**, it "hunts" for business profiles and returns them in a structured, actionable list.

## 🛠️ Tech Stack
* **Backend:** C# / .NET (Handles API consumption, rate limiting, and data processing)
* **Frontend:** React (Provides a dynamic, responsive interface for data visualization)
* **Integration:** Google Business Profile API / Google Places API

## 🔍 Core Functionality
The application features a robust filtering system that allows users to drill down into results based on:
* **Industry:** Target specific niches (e.g., "Plumbing", "Law Firms", "Auto Glass").
* **City/Location:** Geographically targeted searches for local market analysis.
* **Reviews:** Filter by reputation metrics (Star rating and Review count) to find top-rated or under-served businesses.

## 🚀 How It Works
1. User inputs search parameters (City + Industry).
2. The **C# backend** sends a request to the Google API.
3. The app parses the JSON response and applies the **Review/Rating filters**.
4. The **React frontend** renders the "Hunter's List" for the user to export or analyze.

---
*Finished Project - 2026*
