# Flow Of Reason

## The Goal

The purpose of the Flow Of Reason (FOR) is to support people who want to logically trace out and organize arguments 
with supporting materials. The goal is also to allow a broader community to help build the logic graph. 
Many sites help with individual and unique questions, but I want to see how they all fit together.
There are also many books that cover similar ideas, and it feels pointless to read multiple books that have the 
same answers and ideas when the authors could simply make their case on this application with direct links to sources
and other generally accepted arguments rather than in the vacuum of a book.

## The public API

The API will be free to use for public logic trees. It will be limited to a TDB extent to allow the maximum number of
people access to it.

/LogicGraph/
/LogicGraph/{graph id}
/Node/{node id}
/LeadComment/{lead comment id}
/DiscussionComment/{discussion comment id}


## The private API

Via your account, you will have access to an API that allows you access to your own data. Now, this API is also
limited and will not allow your private knowledge trees to grow beyond X size.

## The UI

### User Account

User can manage email, password, and Nick Name

### Search Graphs

In offline mode, this will only show graphs owned or downloaded by the user. In 
online mode, it will allow the user to search for public graphs

This page will allow the user to Select a graph to open or pin. It will also include a button to create a new one.

### Create New Graph

This will allow the user to fill out a form to create a new graph with some settings:
- Private or Public
- Who can own, edit, review, view: List Users
- Types of relationships between nodes (color code optional)
- Types of Nodes (color code optional)
- Name of Graph
- Comment Types

### Wide Graph View

This view shows each node as a small empty circle that is connected by lines representing relationships.
It will include a search bar for quickly searching for nodes.
It will include the ability to click on multiple circles to expand them to previews (headers only).
When expanded, There will be a button to open the full view and a button to pin it.

### Train of Thought View

This will also include a search bar to quickly traverse the graph. 
A node must be marked as the starting node.
The starting node will be the first Current node.
The Current node will be large in the center. Nodes it links to will be arrayed below as the next options.
Clicking on any of the below nodes will make that node the next Current Node.
During this whole time, a line chart will be on the right showing the path and allowing for traversing back.
This chart will be small circles connected linearly by lines. Whenever the "train of thought" repeats a visit to 
a previous node, it shows the return path. This will help show circular reasoning.

## Pinned Graphs

This is particularly if the user has online access. Then the user can download or just pin the graph.

This shows the list of pinned Graphs with their names, descriptions, and other details.

## Owned Graphs

Like Pinned Graphs but these are only ones you own

## Pinned Nodes

A list of nodes you've pinned.

## Node Drafts

In case you've got a draft you've been working on, this allows you to save your work for later.

Comments and Discussions will also be listed but with only a preview and a link to the source.

## Create a Node

A form for creating a Node
- Type 
- Header
- Explanation (Supports linking to other nodes or external URLs)
- Any Additional Relationships

## Existing Node

This represents a Node that already exists. It shows the header, explanation, relationships to other nodes,
date created, last modified, Creator, and Challenges

The Challenges are of any type defined by the graph settings. Generally, they will be duplicate, false, or suggested edit.
Challenges may be further responded to.

## TODO

- [X] Create initial API
- [ ] Create initial Data Bases using SqLite
- [ ] Use longer term Data Bases
- [ ] Add Authentication
- [ ] Add Authorization

