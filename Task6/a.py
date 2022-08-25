import numpy as np
import math


class Node:

    def __init__(self, v):

        self.value = v
        self.inNeighbors = []
        self.outNeighbors = []

        self.status = "unvisited"
        self.estD = np.inf

    def hasOutNeighbor(self, v):

        if v in self.outNeighbors:
            return True

        return False

    def hasInNeighbor(self, v):

        if v in self.inNeighbors:
            return True

        return False

    def hasNeighbor(self, v):

        if v in self.inNeighbors or v in self.outNeighbors:
            return True

        return False

    def getOutNeighbors(self):

        return self.outNeighbors

    def getInNeighbors(self):

        return self.inNeighbors

    def getOutNeighborsWithWeights(self):

        return self.outNeighbors

    def getInNeighborsWithWeights(self):

        return self.inNeighbors

    # ------------------------------------------------
    # Let us modify following two functions to incorporate weights
    # ------------------------------------------------

    def addOutNeighbor(self, v, wt):

        self.outNeighbors.append((v, wt))

    def addInNeighbor(self, v, wt):

        self.inNeighbors.append((v, wt))

    def __str__(self):

        return str(self.value)


class Graph:

    def __init__(self):

        self.vertices = []

    def addVertex(self, n):

        self.vertices.append(n)

    # ------------------------------------------------
    # Let us modify following two functions to incorporate weights
    # ------------------------------------------------

    def addDiEdge(self, u, v, wt=1):

        u.addOutNeighbor(v, wt=wt)
        v.addInNeighbor(u, wt=wt)

    # add edges in both directions between u and v
    def addBiEdge(self, u, v, wt=1):

        self.addDiEdge(u, v, wt=wt)
        self.addDiEdge(v, u, wt=wt)

    # get a list of all the directed edges
    # directed edges are a list of two vertices
    def getDirEdges(self):

        ret = []
        for v in self.vertices:
            ret += [[v, u] for u in v.outNeighbors]
        return ret

    # reverse the edge between u and v.  Multiple edges are not supported.
    def reverseEdge(self, u, v):

        if u.hasOutNeighbor(v) and v.hasInNeighbor(u):

            if v.hasOutNeighbor(u) and u.hasInNeighbor(v):
                return

            self.addDiEdge(v, u)
            u.outNeighbors.remove(v)
            v.inNeighbors.remove(u)

    def __str__(self):

        ret = "Graph with:\n"
        ret += "\t Vertices:\n\t"
        for v in self.vertices:
            ret += str(v) + ","
        ret += "\n"
        ret += "\t Edges:\n\t"
        for a, b in self.getDirEdges():
            ret += "(" + str(a) + "," + str(b) + ") "
        ret += "\n"
        return ret


G = Graph()
# for i in ['0', '1', '2', '3', '4', '5']:
for i in ['S', 'A', 'B']:
    G.addVertex(Node(i))

V = G.vertices

G.addDiEdge(V[0], V[1], 3)
G.addDiEdge(V[0], V[2], 5)
G.addDiEdge(V[1], V[2], -1)

# print(G)

# def dijkstra(w, G):
#     for v in G.vertices:
#         v.estD = math.inf
#
#     w.estD = 0
#     unsureVertices = G.vertices[:]
#
#     paths = []
#     for i in G.vertices:
#         if i.value != w.value:
#             paths.append([w.value])
#
#     sureVertices = []
#
#     while len(unsureVertices) > 0:
#
#         # find the u with the minimum estD in the dumbest way possible
#         u = None
#         minD = math.inf
#         for x in unsureVertices:
#             if x.estD < minD:
#                 minD = x.estD
#                 u = x
#
#         if u == None:
#             # then there is nothing more that I can reach
#             return
#
#         # update u's neighbors
#         for v, wt in u.getOutNeighborsWithWeights():
#
#             if v in sureVertices:
#                 continue
#
#             if u.estD + wt < v.estD:
#                 v.estD = u.estD + wt
#                 for p in paths:
#                     if p[-1] == u.value:
#                         p.append(v.value)
#                         break
#
#         unsureVertices.remove(u)
#         sureVertices.append(u)
#
#
# w = G.vertices[0]
# dijkstra(w, G)


# for v in G.vertices:
#     print(v.value, v.estD)
# def Bellman_Ford(w, G):
#     v_ls = G.vertices
#     n = len(G.vertices)
#     d = [[np.inf for _ in range(n)] for _ in range(n+1)]
#     for sd in d:
#         sd[v_ls.index(w)] = 0
#
#     for i in range(1, n+1):
#         for u in G.vertices:
#             for v, wt in u.getOutNeighborsWithWeights():
#                 d[i][v_ls.index(v)] = min(d[i-1][v_ls.index(v)], d[i-1][v_ls.index(u)] + wt)
#
#     print(d)
#
#
# Bellman_Ford(G.vertices[0], G)


from queue import PriorityQueue


def dijkstra(w, G):
    for v in G.vertices:
        v.estD = math.inf

    w.estD = 0
    unsureVertices = G.vertices[:]

    sureVertices = []

    while len(unsureVertices) > 0:

        # find the u with the minimum estD in the dumbest way possible
        u = None
        # minD = math.inf
        q = PriorityQueue()
        for i, x in enumerate(unsureVertices):
            q.put((x.estD, i))

        u = unsureVertices[q.get()[1]]

        if u == None:
            # then there is nothing more that I can reach
            return

        # update u's neighbors
        for v, wt in u.getOutNeighborsWithWeights():

            if v in sureVertices:
                continue

            if u.estD + wt < v.estD:
                v.estD = u.estD + wt

        unsureVertices.remove(u)
        sureVertices.append(u)


# w = G.vertices[0]
# dijkstra(w, G)
# for v in G.vertices:
#     print(v.value, v.estD)


del G
G = Graph()
for i in ['S', 'U', 'V', 'T']:
    G.addVertex(Node(i))

V = G.vertices

G.addDiEdge(V[0], V[1], 2)
G.addDiEdge(V[1], V[0], 1)
G.addDiEdge(V[0], V[2], 5)
G.addDiEdge(V[1], V[2], 2)
G.addDiEdge(V[2], V[3], -2)
# print(G.vertices.index(V[1]))


def Floyd_warshall(G):
    n = len(G.vertices)
    D = [[np.inf for _ in range(n)] for _ in range(n)]
    for i in range(n):
        D[i][i] = 0

    for u in G.vertices:
        for v, wt in u.getOutNeighborsWithWeights():
            D[G.vertices.index(u)][G.vertices.index(v)] = wt
    # print(D)

    for k in range(n):
        for row in range(n):
            for col in range(n):
                D[row][col] = min(D[row][col], D[row][k]+D[k][col])

    print(D)

Floyd_warshall(G)